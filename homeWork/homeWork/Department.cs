namespace homework
{
    /// <summary>
    /// Класс отдел
    /// </summary>
    public class Department
    {
        //Ключ, название отдела 
        public int id_department;
        public string name_department;

        public Department(int id, string name)
        {
            this.id_department = id;
            this.name_department = name;
        }

        public override string ToString()
        {
            return "(ID = " + this.id_department.ToString() + "; Наименование отдела = " + this.name_department + ")";
        }
    }
}
