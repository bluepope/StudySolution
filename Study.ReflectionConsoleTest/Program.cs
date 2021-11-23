using Study.Lib;
using Study.ReflectionConsoleTest;

using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        string[] copyProperties = new string[] { "Description" };

        StudyPersonModel? iron = null;
        StudyPersonModel? bluepope = null;

        iron = new StudyPersonModel();
        iron.Id = 1;
        iron.Name = "독산동불주먹";
        iron.Description = "스터디 참여자";
        iron.Description1 = "설명1";
        iron.Description2 = "설명2";
        iron.Description3 = "설명3";
        iron.Description4 = "설명4";

        bluepope = new StudyPersonModel();
        bluepope.Id = 2;
        bluepope.Name = "bluepope";
        bluepope.Description = iron.Description;

        //1. Reflection 기초, Property Name 을 string으로 복사하기
        for(int i=1;i <= 4; i++)
        {
            string propertyName = $"Description{i}";

            //_bluepope["Description" + i] = _iron["Description" + i];
            string? description = iron.GetType()?.GetProperty(propertyName)?.GetValue(iron) as string;
            bluepope.GetType()?.GetProperty(propertyName)?.SetValue(bluepope, description);
        }

        //2. 객체단위의 Deep Copy

        // 이렇게 하면 얕은 복사(메모리 참조)가 되기때문에 Deep Copy 가 되지 않음
        //bluepope = iron;
        bluepope = new StudyPersonModel();
        CommonHelper.DeepCopy(iron, bluepope);

        //3. 객체명만 가지고 객체를 생성하는 작업
        string className = "StudyDogModel";

        var dog = Activator.CreateInstance(Type.GetType($"Study.ReflectionConsoleTest.{className}, Study.ReflectionConsoleTest"));
        CommonHelper.DeepCopy(iron, dog);

        Console.WriteLine(iron.Name);
        Console.WriteLine((dog as StudyDogModel).Name);

        //4. Property 이름과 값만 가지고 
        string requestPropertyName = "Description1";
        string requestPropertyValue = "asdf";
        
        //4.A 기존에 리플렉션을 사용하지 않았다면 Property이름 별로 조건문 생성 필요
        if (requestPropertyName == "Description1")
        {
            bluepope.Description1 = requestPropertyValue;
        }
        else if (requestPropertyName == "Description2")
        {
            bluepope.Description2 = requestPropertyValue;
        }

        //4.B 그러나 리플렉션을 사용한다면 간단하게 해결
        bluepope.GetType()?.GetProperty(requestPropertyName)?.SetValue(bluepope, requestPropertyValue);

        string returnValue = bluepope.GetType()?.GetProperty(requestPropertyName)?.GetValue(bluepope) as string;

        Console.WriteLine(returnValue);
    }
}