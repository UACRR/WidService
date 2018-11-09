using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ipsFormsDesign.Utilities
{
    public class AmountDistributor
    {
        public void DistributeByEqualAmount<TSource>(IEnumerable<TSource> list, decimal? amount, Expression<Func<TSource, decimal>> propertySelector)
        {
            var count = list.Count();

            if (count == 0)
                return;

            if (!amount.HasValue || amount == 0)
                return;

            var memberSelectorExpression = propertySelector.Body as MemberExpression;
            PropertyInfo propertyInfo;
            propertyInfo = memberSelectorExpression.Member as PropertyInfo;

            decimal newAmount = amount.Value / count;
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
