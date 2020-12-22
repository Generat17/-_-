namespace homework
{
    /// <summary>
    /// Класс сотрудник
    /// </summary>
    public class Employee
    {
        //Ключ, фамилия сотрудника, ключ отдела
        public int id_employee;
        public string name_employee;
        public int id_department;

        public Employee(int id, string name, int id_department)
        {
            this.id_employee = id;
            this.name_employee = name;
            this.id_department = id_department;
        }
        public override string ToString()
        {
            return "(ID = " + this.id_employee.ToString() + "; Фамилия = " + this.name_employee + "; Отдел = " + this.id_department + ")";
        }
    }
}
