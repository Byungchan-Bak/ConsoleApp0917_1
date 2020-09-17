using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0917_1
{
    class Person
    {
        //property
        private string fName;

        public string FistName
        {
            get { return fName; }
            set { fName = value; }
        }

        private string lName;

        public string LastName
        {
            get { return lName; }
            set { lName = value; }
        }

        public Person(string fName, string lName)   //2파라미터 기본생성자
        {
            this.fName = fName;
            this.lName = lName;
        }

        /*
        public Person() //부모의 기본생성자
        {
            Console.WriteLine("Person생성자 : ");
        }
        */
        public void PrintInfo() //virtural미사용 부모메서드
        {
            Console.WriteLine("=======Person=======");
            Console.WriteLine("First Name : {0}", fName);
            Console.WriteLine("Last Name : {0}", lName);
            Console.WriteLine("=======Person=======");
        }

        public override string ToString()
        {
            return $"{fName} {lName}";
        }
    }

    class Employee : Person    //Man에서 상속 받음.
    {
        int employeeID = 0;

        public Employee()  : base("", "")  //자식의 기본생성자에 대한 힌트
        {
            Console.WriteLine("Employee생성자 : ");
        }

        public Employee(int employeeID) : base("", "")  //1파라미터 기본생성자
        {
            this.employeeID = employeeID;
        }

        public Employee(int employeeID, string fName, string lName) : base(fName, lName)    //3파라미터 기본생성자
        {
            this.employeeID = employeeID;
        }

        public new void PrintInfo() //new를 통해 부모메서드 수정
        {
            Console.WriteLine("=======Employee=======");
            Console.WriteLine("Employee ID : {0}", employeeID);
            Console.WriteLine("First Name : {0}", this.FistName);
            Console.WriteLine("Last Name : {0}", this.LastName);
            Console.WriteLine("=======Employee=======");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //어제 수업시간 예제에서 Man클래스를 Person클래스로 변경만 하였습니다.
            //어제 수업시간에는 property로 "아", "이유"를 저장했지만, 이번에는 생성자로 하고 싶습니다.
            //아래의 코드가 가능하게 Person클래스를 수정하시고, Employee클래스의 emp1은 실행 시 문제가 없는지 확인하세요.
            //문제가 있다면, 무슨 문제가 있는지 생각해보시기 바랍니다.

            Person per = new Person("아", "이유");
            per.PrintInfo();

            Employee emp1 = new Employee(01210313);
            emp1.FistName = "류";
            emp1.LastName = "현진";
            emp1.PrintInfo();

            Employee emp2 = new Employee(20190313, "배", "수지");
            emp2.PrintInfo();

            per = emp1;     // 자식 -->> 부모는 자동 형변환
            per.PrintInfo();
            //override된 메서드인 경우 태생(Employee)의 메서드가 실행
            //new된 메서드인 경우 변수타입(Person)의 메서드가 실행

            emp2 = (Employee)per;
            //1. 부모클래스에 기본생성자를 부여
            //2. 자식생성자에 부모생성자에 대한 힌트 부여(base : 파라미터 개수)

            //Person per = new Person();
            //Employee emp = new Employee();
        }
    }
}
