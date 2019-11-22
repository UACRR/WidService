using System;
using System.Linq.Expressions;

namespace IPSViewComponentLibraryWPF.Extensions
{
    public static class IPSExtensions
    {
        public static string GetPropertyName<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            var memberExpression = (MemberExpression) expression.Body;
            return memberExpression.Member.Name;
        }
    }
}
