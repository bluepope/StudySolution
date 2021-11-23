namespace Study.Lib
{
    public class CommonHelper
    {
        public static void DeepCopy(object source, object target)
        {
            //타입 비교
            /*
            if (source.GetType() != target.GetType())
            {
                throw new Exception("다른 타입");
            }
            */

            foreach (var property in source.GetType()?.GetProperties())
            {
                //동일한 Property가 있다면 복사를 하고 싶다.
                var targetProperty = target.GetType()?.GetProperty(property.Name);

                //두 Property는 자료형이 같아야한다
                if (property.PropertyType == targetProperty?.PropertyType)
                {
                    target.GetType()?.GetProperty(property.Name)?.SetValue(target, property.GetValue(source));
                }
            }
        }
    }
}