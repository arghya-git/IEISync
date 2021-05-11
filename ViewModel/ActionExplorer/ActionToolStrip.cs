using static ViewModel.Enumeration.ActionPropertyEnums;
//using DBSyncBL.RegKey;


namespace ViewModel.ActionExplorer
{
    public class ActionToolStrip
    {
        type _ToolStripType;
        public ActionToolStrip()
        {
            // ActionPropery = new RegKyeDBSyncActionTreeNode();
            // ActionPropery.BgWorker = new System.ComponentModel.BackgroundWorker();
            // ActionPropery.BgWorker.WorkerReportsProgress = true;
            //ActionPropery.BgWorker.WorkerSupportsCancellation = true;



        }

        public ActionToolStrip(RegKyeDBSyncActionTreeNode Propery)
        {
            _ToolStripType = Propery.ActionProperties.Type;
            _ActionPropery = new RegKyeDBSyncActionTreeNode();
            ActionPropery = Propery;
            if (Propery.ActionProperties.Mode == mode.Auto)
            {

                ActionPropery.ActionProperties.StartVisibleBoth = false;    //1
                ActionPropery.ActionProperties.StartVisibleUp = false;    //2
                ActionPropery.ActionProperties.StartVisibleDown = false;    //4

                ActionPropery.ActionProperties.PauseVisibleUp = false;   //8
                ActionPropery.ActionProperties.StopVisibleUp = false;    //32


                ActionPropery.ActionProperties.PauseVisibleDown = false;   //16
                ActionPropery.ActionProperties.StopVisibleDown = false;    //64
            }
        }
        RegKyeDBSyncActionTreeNode _ActionPropery;
        //public RegKyeDBSyncActionTreeNode ActionPropery { get; set; }
        public RegKyeDBSyncActionTreeNode ActionPropery { get => _ActionPropery; set => _ActionPropery = value; }



        string Upword = "Upword:";
        string Downword = "Downword:";

        public string getMode()
        {
            string str = string.Empty;
            if (ActionPropery.ActionProperties.Mode == mode.Auto)
            {
                str = "Auto";
            }
            if (ActionPropery.ActionProperties.Mode == mode.Manual)
            {
                str = "Manual";
            }
            return str;
        }
        //public mode setMode(string Mode)
        //{
        //    if (Mode == "Auto")
        //    {
        //        ActionPropery.ActionProperties.Mode = mode.Auto;


        //    }
        //    if (Mode == "Manual")
        //    {
        //        ActionPropery.ActionProperties.Mode = mode.Manual;
        //    }
        //    return ActionPropery.ActionProperties.Mode;
        //}


        state _CurrentStateUp = state.Stop;
        state _CurrentStateDown = state.Stop;

        private state CurrentStateUp { get => _CurrentStateUp; set => _CurrentStateUp = value; }
        private state CurrentStateDown { get => _CurrentStateDown; set => _CurrentStateDown = value; }
       
        public int changeState(int i)
        {
            //int j = 0;


            if (i == 1)
            {
                //b = true;
                //d = u = !b;

                //stat = i;
                ActionPropery.ActionProperties.StartEnabledBoth = false;
                _CurrentStateUp = state.Running;
                _CurrentStateDown = state.Running;
                ActionPropery.ActionProperties.StopEnabledUp = ActionPropery.ActionProperties.PauseEnabledUp = ActionPropery.ActionProperties.StopEnabledDown =
                    ActionPropery.ActionProperties.PauseEnabledDown = !(ActionPropery.ActionProperties.StartEnabledDown = ActionPropery.ActionProperties.StartEnabledUp = ActionPropery.ActionProperties.StartEnabledBoth);

                ActionPropery.ActionProperties.StartVisibleBoth = false;
                ActionPropery.ActionProperties.StopVisibleUp = ActionPropery.ActionProperties.PauseVisibleUp = ActionPropery.ActionProperties.StopVisibleDown =
                    ActionPropery.ActionProperties.PauseVisibleDown = ActionPropery.ActionProperties.StartVisibleDown = ActionPropery.ActionProperties.StartVisibleUp = !(ActionPropery.ActionProperties.StartVisibleBoth);

                //Text = "Running (Both direction) ... ";
            }
            if (i == 2)
            {
                //u = true;
                //b = u && d;
                //u = d = !b;
                //stat = i;
                ActionPropery.ActionProperties.StartEnabledUp = false;
                _CurrentStateUp = state.Running;

                ActionPropery.ActionProperties.StopEnabledUp = ActionPropery.ActionProperties.PauseEnabledUp = !ActionPropery.ActionProperties.StartEnabledUp;
                ActionPropery.ActionProperties.StartEnabledBoth = (ActionPropery.ActionProperties.StartEnabledUp && ActionPropery.ActionProperties.StartEnabledDown);

                ActionPropery.ActionProperties.StartVisibleUp = true;
                ActionPropery.ActionProperties.StopVisibleUp = ActionPropery.ActionProperties.PauseVisibleUp = ActionPropery.ActionProperties.StartVisibleUp;
                ActionPropery.ActionProperties.StartVisibleBoth = ActionPropery.ActionProperties.StartEnabledBoth;
                //if(_CurrentStateDown == State.Running)
                //    Text = "Running (Both direction) ... ";
                //else
                //    Text = "Running (Oracle to SqlServer)... ";

            }
            if (i == 4)
            {
                //d = true;
                //b = u && d;
                //u = d = !b;

                //stat = i;
                ActionPropery.ActionProperties.StartEnabledDown = false;
                _CurrentStateDown = state.Running;

                ActionPropery.ActionProperties.StopEnabledDown = ActionPropery.ActionProperties.PauseEnabledDown =
                    !ActionPropery.ActionProperties.StartEnabledDown;
                ActionPropery.ActionProperties.StartEnabledBoth = (ActionPropery.ActionProperties.StartEnabledUp && ActionPropery.ActionProperties.StartEnabledDown);

                ActionPropery.ActionProperties.StartVisibleDown = true;
                ActionPropery.ActionProperties.StopVisibleDown = ActionPropery.ActionProperties.PauseVisibleDown = ActionPropery.ActionProperties.StartVisibleDown;
                ActionPropery.ActionProperties.StartVisibleBoth = ActionPropery.ActionProperties.StartEnabledBoth;
                //if (_CurrentStateUp == State.Running)
                //    Text = "Running (Both direction) ... ";
                //else
                //    Text = "Running (SqlServer to Oracle)... ";

            }
            if (i == 8)
            {
                ActionPropery.ActionProperties.PauseEnabledUp = false;
                ActionPropery.ActionProperties.StopEnabledUp = ActionPropery.ActionProperties.StartEnabledUp = !ActionPropery.ActionProperties.PauseEnabledUp;

                ActionPropery.ActionProperties.PauseVisibleUp = true;
                ActionPropery.ActionProperties.StopVisibleUp = ActionPropery.ActionProperties.StartVisibleUp = ActionPropery.ActionProperties.PauseVisibleUp;

                _CurrentStateUp = state.Paused;


                //if (_CurrentStateDown == State.Paused)
                //    Text = "Paused (Both direction)... ";
                //else if (_CurrentStateDown == State.Running)
                //    Text = "Running (SqlServer to Oracle)...";
                //else if (_CurrentStateDown == State.Stop)
                //    Text = "Paused (Oracle to SqlServer)... ";
            }
            if (i == 16)
            {
                ActionPropery.ActionProperties.PauseEnabledDown = false;
                _CurrentStateDown = state.Paused;

                ActionPropery.ActionProperties.StartEnabledDown = ActionPropery.ActionProperties.StopEnabledDown = !ActionPropery.ActionProperties.PauseEnabledDown;

                ActionPropery.ActionProperties.PauseVisibleDown = true;
                ActionPropery.ActionProperties.StartVisibleDown = ActionPropery.ActionProperties.StopVisibleDown = ActionPropery.ActionProperties.PauseVisibleDown;


                //if (_CurrentStateUp == State.Paused)
                //    Text = "Paused (Both direction)... ";
                //else if (_CurrentStateUp == State.Running)
                //    Text = "Running (Oracle to SqlServer)...";
                //else if (_CurrentStateUp == State.Stop)
                //    Text = "Paused (SqlServer to Oracle)... ";

            }
            if (i == 32)
            {
                ActionPropery.ActionProperties.StopEnabledUp = false;
                _CurrentStateUp = state.Stop;

                ActionPropery.ActionProperties.StartEnabledUp = !(ActionPropery.ActionProperties.PauseEnabledUp = ActionPropery.ActionProperties.StopEnabledUp);
                ActionPropery.ActionProperties.StartEnabledBoth = ActionPropery.ActionProperties.StartEnabledUp && ActionPropery.ActionProperties.StartEnabledDown;

                ActionPropery.ActionProperties.StopVisibleUp = false;
                ActionPropery.ActionProperties.StartVisibleUp = !(ActionPropery.ActionProperties.PauseVisibleUp = ActionPropery.ActionProperties.StopVisibleUp);
                ActionPropery.ActionProperties.StartVisibleBoth = ActionPropery.ActionProperties.StartEnabledBoth;

                //if (_CurrentStateDown == State.Paused)
                //    Text = "Paused (Both direction)... ";
                //else if (_CurrentStateDown == State.Running)
                //    Text = "Running (SqlServer to Oracle)...";
                //else if (_CurrentStateDown == State.Stop)
                //    Text = "Stop Syncronization... ";
            }
            if (i == 64)
            {
                ActionPropery.ActionProperties.StopEnabledDown = false;
                _CurrentStateDown = state.Stop;

                ActionPropery.ActionProperties.StartEnabledDown = !(ActionPropery.ActionProperties.PauseEnabledDown = ActionPropery.ActionProperties.StopEnabledDown);
                ActionPropery.ActionProperties.StartEnabledBoth = ActionPropery.ActionProperties.StartEnabledUp && ActionPropery.ActionProperties.StartEnabledDown;

                ActionPropery.ActionProperties.StopVisibleDown = false;
                ActionPropery.ActionProperties.StartVisibleDown = !(ActionPropery.ActionProperties.PauseVisibleDown = ActionPropery.ActionProperties.StopVisibleDown);
                ActionPropery.ActionProperties.StartVisibleBoth = ActionPropery.ActionProperties.StartEnabledBoth;

            }

            if (_CurrentStateUp == state.Paused)
                Upword = "Upword: Paused";
            if (_CurrentStateUp == state.Running)
                Upword = "Upword: Running";
            if (_CurrentStateUp == state.Stop)
                Upword = "Upword: Stop";
            if (_CurrentStateDown == state.Paused)
                Downword = "Downword: Paused";
            if (_CurrentStateDown == state.Running)
                Downword = "Downword: Running";
            if (_CurrentStateDown == state.Stop)
                Downword = "Downword: Stop";

            ActionPropery.ActionProperties.Text = Upword + ", " + Downword;
            return i;
        }
    }
}
