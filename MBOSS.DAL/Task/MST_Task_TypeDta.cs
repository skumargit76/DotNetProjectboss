using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Mboss.DataAccessObject;

namespace Mboss.DataAccess.Task
{
    public class TaskTypesDta : Base
    {
        public List<Mboss.DataAccessObject.Task.TaskTypeByGroupid> TaskTypes(string RoleCode)
        {
            var reader = ExecuteReader("USP_Get_Task_Types_By_RoleCode"
                , new SqlParameter("@RoleCode", RoleCode));
            List<Mboss.DataAccessObject.Task.TaskTypeByGroupid> TaskTypeItems
                = new List<DataAccessObject.Task.TaskTypeByGroupid>();
            while (reader.Read())
            {
                Mboss.DataAccessObject.Task.TaskTypeByGroupid TaskTypeItemsList
                    = new DataAccessObject.Task.TaskTypeByGroupid();
                TaskTypeItemsList.TASK_TYPE_CODE = reader.GetString("TASK_TYPE_CODE");
                TaskTypeItemsList.TASK_TYPE_NAME = reader.GetString("TASK_TYPE_NAME");
                TaskTypeItems.Add(TaskTypeItemsList);
            }
            reader.Close();
            return TaskTypeItems;
        }
    }
}
