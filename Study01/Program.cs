using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Net;

namespace Study01
{
    class Program
    {
        static void Main(string[] args)
        {
            //깊은 참조, Deep Copy, Call by Value --. 값이 복사가 된다.
            //얕은 참조, Shallow copy, Call by Reference -- 객체의 주소가 복사된다.

            //var 
            string name = "안현모";
            int age = 39;
            StudyPerson bluepope = new StudyPerson(name, age);
            ShallowCopyTest(bluepope);

            Console.WriteLine(bluepope.GetAge());

            /*
            name = "최수혁";
            age = 29;
            StudyPerson choisuhyuk = new StudyPerson(name, age);

            choisuhyuk.AddAge(5);

            Console.WriteLine(choisuhyuk.GetAge());
            */
        }

        static void ShallowCopyTest(StudyPerson person)
        {
            person.AddAge(100);
        }
    }

    public class StudyPerson
    {
        //프로퍼티=속성=Property
        public string Name { get; set; }
        public int Age { get; set; }

        public StudyPerson(string name, int age)
        {
            name = name + "!!!!";
            this.Name = name;
            this.Age = age;
        }

        public string GetName()
        {
            return this.Name;
        }

        public int GetAge()
        {
            return this.Age;
        }

        public void AddAge(int add)
        {
            this.Age = this.Age + add;
        }
    }
}