using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  class IrgendwasController
  {
    private Timer timer;
    public IrgendwasController()
    {
      timer = new Timer(new TimerCallback(this.TimerTick), null, 0, 1000);
    }

    private void TimerTick(object state)
    {
      // ...
    }
  }
}
