using NFluent;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace HexagonalRealEstate.Tests
{
    public static class TestExtensions
    {
        public static void SetProperty<TSource, TProperty>(
            this TSource source,
            Expression<Func<TSource, TProperty>> prop,
            TProperty value)
        {
            var propertyInfo = (PropertyInfo)((MemberExpression)prop.Body).Member;
            propertyInfo.SetValue(source, value);
        }

        public static ILambdaExceptionCheck<T> ThrowsFromRecursivity<T>(this ICodeCheck<RunTrace> codeCheck) where T : Exception
        {
            return codeCheck.Throws<TargetInvocationException>().DueTo<T>();
        }
    }
}
