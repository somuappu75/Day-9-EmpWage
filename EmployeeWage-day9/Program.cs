using System;
using System.Collections.Generic;

namespace EmployeeWage_day9
{
    public interface IcomputeEmpWage
    {

        public void addcompanyEmpWage(string company, int empRatePerHour, int numofWorkingDays, int maxHoursPerMonth);

        public void computeEmpWage();

        public int getTotalWage(string company);
    }
    public class CompanyEmpWage
    {
        public string company;
        public int empRatePerHour;
        public int numofWorkingDays;
        public int maxHoursPerMonth;
        public int totalEmpWage;
        internal int totalEmpwWge;

        public CompanyEmpWage(string company, int empRatePerHour, int numofWorkingDays, int maxHoursPerMonth)
        {
            this.company = company;
            this.empRatePerHour = empRatePerHour;
            this.numofWorkingDays = numofWorkingDays;
            this.maxHoursPerMonth = maxHoursPerMonth;
            this.totalEmpWage = 0;
        }
        public void setTotalEmpWage(int totalEmpWage)
        {
            this.totalEmpWage = totalEmpWage;
        }

        public string toString()
        {
            return "total Emp Wage for company:" + this.company + " is:" + this.totalEmpWage;
        }
    }


    public class EmpWageBuilder : IcomputeEmpWage
    {
        public const int IS_PART_TIME = 1;
        public const int IS_FULL_TIME = 2;

        private LinkedList<CompanyEmpWage> companyEmpWageList;
        private Dictionary<string, CompanyEmpWage> companyToEmpWagemap;

        public EmpWageBuilder()
        {
            this.companyEmpWageList = new LinkedList<CompanyEmpWage>();
            this.companyToEmpWagemap = new Dictionary<string, CompanyEmpWage>();
        }

        public void addCompanyEmpWage(string company, int empRatePerHour, int numofWorkingDays, int maxHoursperMonth)
        {
            CompanyEmpWage companyEmpWage = new CompanyEmpWage(company, empRatePerHour, numofWorkingDays, maxHoursperMonth);
            this.companyEmpWageList.AddLast(companyEmpWage);
            this.companyToEmpWagemap.Add(company, companyEmpWage);
        }

        public void computeEmpWage()
        {
            foreach (CompanyEmpWage companyEmpWage in this.companyEmpWageList)
            {
                companyEmpWage.setTotalEmpWage(this.computeEmpWage(companyEmpWage));
                Console.WriteLine(companyEmpWage.toString());
            }
        }
        private int computeEmpWage(CompanyEmpWage companyEmpWage);
            

        public int getTotalWage(string company)
        {
            return this.companyToEmpWagemap[company].totalEmpwWge;
        }

        public void addcompanyEmpWage(string company, int empRatePerHour, int numofWorkingDays, int maxHoursPerMonth)
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            EmpWageBuilder empWageBuilder = new EmpWageBuilder();
            empWageBuilder.addCompanyEmpWage("Microsoft", 20, 2, 10);
            empWageBuilder.addCompanyEmpWage("Wipro", 10, 4, 20);
            empWageBuilder.computeEmpWage();
            Console.WriteLine("Total Wage For Mocrosoft Company:" + empWageBuilder.getTotalWage("Microsoft"));

        }
    }
}
