using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ipsFormsDesign.Utilities
{
    public class AmountDistributor
    {
        public decimal Amount { get; set; }
        
        public void DistributeByEqualAmount<TSource>(IEnumerable<TSource> list, Expression<Func<TSource, decimal>> propertySelector)
        {
            var memberSelectorExpression = propertySelector.Body as MemberExpression;
            PropertyInfo propertyInfo;
            propertyInfo = memberSelectorExpression.Member as PropertyInfo;

            var count = list.Count();
            decimal newAmount = Amount / count;
            decimal newRoundAmount = Math.Round(newAmount, 2);
            var delta = Math.Round((newAmount - newRoundAmount) * count, 2);

            foreach (var item in list)
            {
                var distrAmount = newRoundAmount + delta;
                propertyInfo.SetValue(item, distrAmount, null);

                delta = 0;
            }
        }
    }
}
