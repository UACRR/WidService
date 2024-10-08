using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidExport
{
    public class WaitCursor : IDisposable
    {
        private Cursor m_oldCursor = null;

        public WaitCursor()
        {
            m_oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
        }

        public void Dispose()
        {
            Cursor.Current = m_oldCursor;
        }
    }
}
