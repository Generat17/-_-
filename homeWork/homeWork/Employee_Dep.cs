namespace homework
{
    /// <summary>
    /// Связь между списками
    /// </summary>
    public class Employee_Dep
    {
        public int id_employee;
        public int id_department;

        public Employee_Dep(int i1, int i2)
        {
            this.id_department = i1;
            this.id_employee = i2;
        }
        public override string ToString()
        {
            return "(ID Сотрудника = " + this.id_employee.ToString() + "; ID Отдела = " + this.id_department + ")";
        }
    }
}
