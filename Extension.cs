using Geode.Extension;
using Geode.Network;
using Geode.Habbo;
using System.Windows.Forms;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace GeodeExampleCSharp
{
    [Module("GetGuestRoom", "JustProDylan", "Get access to a full room as soon as space is available")]
    public class Extension : GService
    {
        int roomId;
        public MainWindow MainWindowParent;
        public Extension(MainWindow MainWindowParent)
        {
            this.MainWindowParent = MainWindowParent;
        }
        internal void OutChat()
        {
            throw new NotImplementedException();
        }
        [OutDataCapture("OpenFlatConnection")]
        public void SlideObjectBundle1(DataInterceptedEventArgs e)
        {
            roomId = e.Packet.ReadInt32();
        }
        [InDataCapture("RoomReady")]
        public void RoomReady(DataInterceptedEventArgs e)
        {
            MainWindowParent.timer1.Enabled = false;
            MainWindowParent.checkBox1.Checked = false;
            MainWindowParent.checkBox1.Enabled = false;

        }
        [InDataCapture("CantConnect")]
        public void CantConnect(DataInterceptedEventArgs e)
        {
            MainWindowParent.checkBox1.Enabled = true;
        }
        public void OpenFlatConnection()
        {
            SendToServerAsync(Out.GetGuestRoom, roomId, 0, 1);
        }
    }
}
