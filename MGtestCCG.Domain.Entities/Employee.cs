namespace MGtestCCG.Domain.Entities
{
    public class Employee : DomainEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public double HourlySalary { get; set; }
        public double MonthlySalary { get; set; }

        public int TypeContract { get; set; }

        public string PhoneNumber { get; set; }
    }
}
