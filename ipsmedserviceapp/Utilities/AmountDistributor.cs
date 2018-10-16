using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ipsmedserviceapp.Utilities
{
    public class AmountDistributor
    {
        public decimal Amount { get; set; }
        
        public void DistributeByEqualAmount<TSource>(IEnumerable<TSource> list, Expression<Func<TSource, decimal?>> propertySelector)
        {
            var count = list.Count();

            if (count == 0)
                return;

            var memberSelectorExpression = propertySelector.Body as MemberExpression;
            PropertyInfo propertyInfo;
            propertyInfo = memberSelectorExpression.Member as PropertyInfo;

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

        public void DistributeByProperty<TSource>(IEnumerable<TSource> list, Func<TSource, decimal?> amountBasePropertySelector, Expression<Func<TSource, decimal?>> targetPropertySelector)
        {
            if (!list.Any())
                return;

            var memberSelectorExpression = targetPropertySelector.Body as MemberExpression;
            PropertyInfo propertyInfo;
            propertyInfo = memberSelectorExpression.Member as PropertyInfo;

            var totalBaseAmount = list.Sum(x => amountBasePropertySelector(x));
            decimal totalDistrAmount = 0;

            foreach (var item in list)
            {
                var baseAmount = amountBasePropertySelector(item);

                var distrAmount = Math.Round(Amount * baseAmount.Value / totalBaseAmount.Value, 2);

                totalDistrAmount += distrAmount;

                propertyInfo.SetValue(item, distrAmount);
            }

            var delta = Math.Round(Amount - totalDistrAmount, 2);
            if (delta != 0)
            {
                var maxItem = list.OrderByDescending(x => amountBasePropertySelector(x)).First();
                var valueWithDelta = (decimal?)propertyInfo.GetValue(maxItem) + delta;
                propertyInfo.SetValue(maxItem, valueWithDelta);
            }
        }
    }
}
