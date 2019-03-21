using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Interfaces;

namespace IpsViewComponentLibrary.ConsumerControls
{
    public class ViewsSingleton
    {
        public static ConsumerBigRightView ConsumerBigRightView { get; private set; }

        public static ConsumerBigRightView GetConsumerBigRightView()
        {
            return ConsumerBigRightView;
        }

        public static void SetConsumerBigRightView(ConsumerBigRightView view)
        {
            ConsumerBigRightView = view;
        }
    }
}
