using CMSDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSBusinessLayer
{
    public class clsDepartments
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }

        public clsDepartments(int departmentID, string departmentName, string description)
        {
            DepartmentID = departmentID;
            DepartmentName = departmentName;
            Description = description;
        }

        public clsDepartments()
        {
            DepartmentID = -1;
            DepartmentName = "";
            Description = "";
        }


        public static clsDepartments Find(int departmentID) {

            string departmentName = "", description = "";

            if (clsDepartmentsData.GetDepartmentByID(departmentID, ref departmentName, ref description))
                return new clsDepartments(departmentID, departmentName, description);

            else
                return null;
        }

        public static clsDepartments Find(string departmentName)
        {

            string description = "";
            int departmentID = -1;

            if (clsDepartmentsData.GetDepartmentByName(departmentName, ref departmentID, ref description))
                return new clsDepartments(departmentID, departmentName, description);

            else
                return null;
        }

        public static DataTable GetAllDepartments()
        {
            return clsDepartmentsData.GetAllDepartments();
        }
    }
}
