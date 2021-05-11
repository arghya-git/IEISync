﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBSyncBL.RegKey
{
    public class CrossThreadHandler
    {
            public void SafeInvoke(Control uiElement, Action updater, bool forceSynchronous)
            {
                if (uiElement == null)
                {
                    throw new ArgumentNullException("uiElement");
                }

                if (uiElement.InvokeRequired)
                {
                    if (forceSynchronous)
                    {
                        uiElement.Invoke((Action)delegate { SafeInvoke(uiElement, updater, forceSynchronous); });
                    }
                    else
                    {
                        uiElement.BeginInvoke((Action)delegate { SafeInvoke(uiElement, updater, forceSynchronous); });
                    }
                }
                else
                {
                    if (uiElement.IsDisposed)
                    {
                        throw new ObjectDisposedException("Control is already disposed.");
                    }

                    updater();
                }
            }
        }
    }
