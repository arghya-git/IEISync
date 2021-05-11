using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ActionExplorer;
using System.Reflection;
using Microsoft.Win32;
using static ViewModel.Enumeration.ActionPropertyEnums;
using System.ComponentModel;
using System.Windows.Forms;

namespace DBSyncBL.RegKey
{
    public static class RegKeySettings
    {
        static List<RegKyeDBSyncActionTreeNode> _Nodes = new List<RegKyeDBSyncActionTreeNode>();

        static RegKyeDBSyncActionTreeNode _NodeRootDataSynchronization = new RegKyeDBSyncActionTreeNode();
        static RegKyeDBSyncActionTreeNode _NodePayments = new RegKyeDBSyncActionTreeNode();
        static RegKyeDBSyncActionTreeNode _NodeLeafDirect = new RegKyeDBSyncActionTreeNode();
        static RegKyeDBSyncActionTreeNode _NodeLeafIndirect = new RegKyeDBSyncActionTreeNode();
        static RegKyeDBSyncActionTreeNode _NodeFile = new RegKyeDBSyncActionTreeNode();
        static RegKyeDBSyncActionTreeNode _NodeMembership = new RegKyeDBSyncActionTreeNode();
        static RegKyeDBSyncActionTreeNode _NodeLeafMembershipApplication = new RegKyeDBSyncActionTreeNode();
        static RegKyeDBSyncActionTreeNode _NodeLeafChangeAddress = new RegKyeDBSyncActionTreeNode();
        static RegKyeDBSyncActionTreeNode _NodeLeafMemberData = new RegKyeDBSyncActionTreeNode();
        static RegKyeDBSyncActionTreeNode _NodeDataSynchronization = new RegKyeDBSyncActionTreeNode();
        static RegKyeDBSyncActionTreeNode _NodeExamination = new RegKyeDBSyncActionTreeNode();
        static RegKyeDBSyncActionTreeNode _NodeTechnicalActivities = new RegKyeDBSyncActionTreeNode();


        public static List<RegKyeDBSyncActionTreeNode> Nodes { get => _Nodes; }


      

        static void init()
        {
            _NodeRootDataSynchronization.Name = "NodeDataSynchronization";
            _NodeRootDataSynchronization.Type = "RootNode";
            ISynchronizeInvoke synchronizingObject = new Control();
            _NodeRootDataSynchronization.ActionProperties = new RegKyeDBSyncActionProperties();
            Nodes.Add(_NodeRootDataSynchronization);

            _NodePayments.Name = "NodePayments";
            _NodePayments.Type = "ChiledNode";
            _NodePayments.ActionProperties = new RegKyeDBSyncActionProperties();
            Nodes.Add(_NodePayments);

            _NodeLeafDirect.Name = "NodeDirect";
            _NodeLeafDirect.Type = "LeafNode";
            _NodeLeafDirect.ActionProperties = new RegKyeDBSyncActionProperties();
            Nodes.Add(_NodeLeafDirect);

            _NodeLeafIndirect.Name = "NodeIndirect";
            _NodeLeafIndirect.Type = "LeafNode";
            _NodeLeafIndirect.ActionProperties = new RegKyeDBSyncActionProperties();
            Nodes.Add(_NodeLeafIndirect);

            _NodeFile.Name = "NodeFile";
            _NodeFile.Type = "LeafNode";
            _NodeFile.ActionProperties = new RegKyeDBSyncActionProperties();
            Nodes.Add(_NodeFile);

            _NodeMembership.Name = "NodeMembership";
            _NodeMembership.Type = "ChiledNode";
            _NodeMembership.ActionProperties = new RegKyeDBSyncActionProperties();
            Nodes.Add(_NodeMembership);

            _NodeLeafMembershipApplication.Name = "NodeMembershipApplication";
            _NodeLeafMembershipApplication.Type = "LeafNode";
            _NodeLeafMembershipApplication.ActionProperties = new RegKyeDBSyncActionProperties();
            Nodes.Add(_NodeLeafMembershipApplication);

            _NodeLeafChangeAddress.Name = "NodeChangeAddress";
            _NodeLeafChangeAddress.Type = "LeafNode";
            _NodeLeafChangeAddress.ActionProperties = new RegKyeDBSyncActionProperties();
            Nodes.Add(_NodeLeafChangeAddress);

            _NodeLeafMemberData.Name = "NodeMemberData";
            _NodeLeafMemberData.Type = "LeafNode";
            _NodeLeafMemberData.ActionProperties = new RegKyeDBSyncActionProperties();
            Nodes.Add(_NodeLeafMemberData);



            _NodeExamination.Name = "NodeExamination";
            _NodeExamination.Type = "ChiledNode";
            _NodeExamination.ActionProperties = new RegKyeDBSyncActionProperties();
            Nodes.Add(_NodeExamination);

            _NodeTechnicalActivities.Name = "NodeTechnicalActivities";
            _NodeTechnicalActivities.Type = "ChiledNode";
            _NodeTechnicalActivities.ActionProperties = new RegKyeDBSyncActionProperties();
            Nodes.Add(_NodeTechnicalActivities);
        }
        public static void setRegKeyAllDefault()
        {
            init();

            foreach (RegKyeDBSyncActionTreeNode node in Nodes)
            {
                Microsoft.Win32.RegistryKey key_DBNode;
                key_DBNode = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("DBSync").CreateSubKey("ActionTreeNodes").CreateSubKey(node.Name);

                try
                {
                    key_DBNode.SetValue("Type", node.Type);
                    key_DBNode.SetValue("Name", node.Name);
                }
                catch
                {

                }

                Microsoft.Win32.RegistryKey key_DBSync;
                key_DBSync = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("DBSync").CreateSubKey("ActionTreeNodes").CreateSubKey(node.Name).CreateSubKey("Properties");


                try
                {

                    key_DBSync.SetValue("StartVisibleBoth", node.ActionProperties.StartVisibleBoth);
                    key_DBSync.SetValue("StartVisibleUp", node.ActionProperties.StartVisibleUp);
                    key_DBSync.SetValue("StartVisibleDown", node.ActionProperties.StartVisibleDown);
                    key_DBSync.SetValue("PauseVisibleUp", node.ActionProperties.PauseVisibleUp);

                    key_DBSync.SetValue("StopVisibleUp", node.ActionProperties.StopVisibleUp);
                    key_DBSync.SetValue("PauseVisibleDown", node.ActionProperties.PauseVisibleDown);
                    key_DBSync.SetValue("StopVisibleDown", node.ActionProperties.StopVisibleDown);
                    key_DBSync.SetValue("StartEnabledBoth", node.ActionProperties.StartEnabledBoth);

                    key_DBSync.SetValue("StartEnabledUp", node.ActionProperties.StartEnabledUp);
                    key_DBSync.SetValue("StartEnabledDown", node.ActionProperties.StartEnabledDown);
                    key_DBSync.SetValue("PauseEnabledUp", node.ActionProperties.PauseEnabledUp);
                    key_DBSync.SetValue("StopEnabledUp", node.ActionProperties.StopEnabledUp);

                    key_DBSync.SetValue("PauseEnabledDown", node.ActionProperties.PauseEnabledDown);
                    key_DBSync.SetValue("StopEnabledDown", node.ActionProperties.StopEnabledDown);
                    key_DBSync.SetValue("Mode", node.ActionProperties.Mode);

                    key_DBSync.SetValue("Text", node.ActionProperties.Text);

                    key_DBSync.SetValue("StateUP", node.ActionProperties.StateUP);
                    key_DBSync.SetValue("StateDown", node.ActionProperties.StateDown);
                    key_DBSync.SetValue("Interval", node.ActionProperties.Schedule.Interval);
                    key_DBSync.SetValue("Unit", node.ActionProperties.Schedule.IntervalUnit);
                    key_DBSync.SetValue("ScheduleDate", node.ActionProperties.Schedule.ScheduleDate);
                    key_DBSync.SetValue("IntMode", node.ActionProperties.Schedule.IntMode);
                }
                catch(Exception ex)
                {
                    //key_DBNode.SetValue(KeyAttribute, KeyValue);
                }


            }
        }

        public static RegKyeDBSyncActionTreeNode setRegKey(string KeyNode, string KeyAttribute, string KeyValue)
        {
            //init();
            RegKyeDBSyncActionTreeNode ret =new RegKyeDBSyncActionTreeNode();
            foreach (RegKyeDBSyncActionTreeNode node in Nodes)
            {
                if (node.Name == KeyNode)
                {
                    RegistryKey key_DBNode;
                    key_DBNode = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("DBSync").CreateSubKey("ActionTreeNodes").CreateSubKey(KeyNode).CreateSubKey("Properties");

                    try
                    {
                        key_DBNode.SetValue(KeyAttribute, KeyValue);

                        ret = getKeyProp(KeyNode);
                       
                        break;

                    }
                    catch
                    {
                        
                    }

                }
            }
            return ret;
    
        }

        public static RegKyeDBSyncActionTreeNode getKeyProp(string Name)
        {
            RegKyeDBSyncActionTreeNode obj = new RegKyeDBSyncActionTreeNode();

            RegistryKey dbSyncKey = Registry.CurrentUser.OpenSubKey(@"DBSync\ActionTreeNodes");
            obj.Name = Name;
            try
            {
                if (dbSyncKey == null)
                {
                    Registry.CurrentUser.Close();
                    setRegKeyAllDefault();
                    dbSyncKey = Registry.CurrentUser.OpenSubKey(@"DBSync\ActionTreeNodes");
                    obj.Name = Name;
                    //return null;
                }

                string[] subKeyNames = dbSyncKey.GetSubKeyNames();

                foreach (string subKeyName in subKeyNames)
                {
                    if (Name == subKeyName)
                    {
                        RegistryKey subKey = dbSyncKey.OpenSubKey(subKeyName);
                        try
                        {
                            if (subKey == null)
                            {
                                return null;
                            }
                            obj.ActionProperties = new RegKyeDBSyncActionProperties();
                            obj.ActionProperties.Schedule = new Schedule();

                            obj.Type = subKey.GetValue("Type").ToString();
                            RegistryKey prop = subKey.OpenSubKey("Properties");

                            var xx = prop.GetValue("StartVisibleBoth");

                            obj.ActionProperties.Name = subKeyName;
                            obj.ActionProperties.StartVisibleBoth = prop.GetValue("StartVisibleBoth").ToString() == "True" ? true : false;
                            obj.ActionProperties.StartVisibleUp = prop.GetValue("StartVisibleUp").ToString() == "True" ? true : false;
                            obj.ActionProperties.StartVisibleDown = prop.GetValue("StartVisibleDown").ToString() == "True" ? true : false;
                            obj.ActionProperties.PauseVisibleUp = prop.GetValue("PauseVisibleUp").ToString() == "True" ? true : false;
                            obj.ActionProperties.StopVisibleUp = prop.GetValue("StopVisibleUp").ToString() == "True" ? true : false;
                            obj.ActionProperties.PauseVisibleDown = prop.GetValue("PauseVisibleDown").ToString() == "True" ? true : false;
                            obj.ActionProperties.StopVisibleDown = prop.GetValue("StopVisibleDown").ToString() == "True" ? true : false;
                            obj.ActionProperties.StartEnabledBoth = prop.GetValue("StartEnabledBoth").ToString() == "True" ? true : false;
                            obj.ActionProperties.StartEnabledUp = prop.GetValue("StartEnabledUp").ToString() == "True" ? true : false;
                            obj.ActionProperties.StartEnabledDown = prop.GetValue("StartEnabledDown").ToString() == "True" ? true : false;
                            obj.ActionProperties.PauseEnabledUp = prop.GetValue("PauseEnabledUp").ToString() == "True" ? true : false;
                            obj.ActionProperties.StopEnabledUp = prop.GetValue("StopEnabledUp").ToString() == "True" ? true : false;
                            obj.ActionProperties.PauseEnabledDown = prop.GetValue("PauseEnabledDown").ToString() == "True" ? true : false;
                            obj.ActionProperties.StopEnabledDown = prop.GetValue("StopEnabledDown").ToString() == "True" ? true : false;
                            obj.ActionProperties.Mode = (mode)Enum.Parse(typeof(mode), prop.GetValue("Mode").ToString());
                            obj.ActionProperties.Text = prop.GetValue("Text").ToString();
                            obj.ActionProperties.Type = (type)Enum.Parse(typeof(type), obj.Type.ToString());
                            obj.ActionProperties.StateUP = (state)Enum.Parse(typeof(state), prop.GetValue("StateUP").ToString());
                            obj.ActionProperties.StateDown = (state)Enum.Parse(typeof(state), prop.GetValue("StateDown").ToString());
                            obj.ActionProperties.Schedule.Interval = Convert.ToInt32(prop.GetValue("Interval").ToString());
                            obj.ActionProperties.Schedule.IntervalUnit = (intervalUnit)Enum.Parse(typeof(intervalUnit), prop.GetValue("Unit").ToString());
                            obj.ActionProperties.Schedule.ScheduleDate = Convert.ToDateTime(prop.GetValue("ScheduleDate").ToString());
                            obj.ActionProperties.Schedule.IntMode = (IntervalMode)Enum.Parse(typeof(IntervalMode), prop.GetValue("IntMode").ToString());
                            obj.ActionProperties.Buffer = Convert.ToInt32(prop.GetValue("Buffer"));

                            break;
                        }
                        catch(Exception ex)
                        {
                            break;
                        }
                        finally
                        {

                        }
                    }
                }
            }
            catch
            {
                return null;
            }

            return obj;
        }


        public static List<RegKyeDBSyncActionTreeNode> getAllKeyProp()
        {
            List<RegKyeDBSyncActionTreeNode> _Properties = new List<RegKyeDBSyncActionTreeNode>();



            

            RegistryKey dbSyncKey = Registry.CurrentUser.OpenSubKey(@"DBSync\ActionTreeNodes");
            //obj.Name = Name;
            try
            {
                if (dbSyncKey == null)
                {
                    return null;
                }

                string[] subKeyNames = dbSyncKey.GetSubKeyNames();
               
              
                foreach (string subKeyName in subKeyNames)
                {
                    RegKyeDBSyncActionTreeNode _Property = new RegKyeDBSyncActionTreeNode();
                    //if (Name == subKeyName)
                    //{
                    RegistryKey subKey = dbSyncKey.OpenSubKey(subKeyName);
                    try
                    {
                        if (subKey == null)
                        {
                            return null;
                        }

                        _Property.ActionProperties = new RegKyeDBSyncActionProperties();
                        _Property.ActionProperties.Schedule = new Schedule();

                        try { _Property.Type = subKey.GetValue("Type").ToString(); } catch { }


                        RegistryKey prop = subKey.OpenSubKey("Properties");

                        
                        try { _Property.Name = subKeyName; } catch { }
                        try { _Property.ActionProperties.Name = subKeyName; } catch { }
                        try { _Property.ActionProperties.StartVisibleBoth = prop.GetValue("StartVisibleBoth").ToString() == "True" ? true : false; } catch { }
                        try { _Property.ActionProperties.StartVisibleUp = prop.GetValue("StartVisibleUp").ToString() == "True" ? true : false; } catch { }
                        try { _Property.ActionProperties.StartVisibleDown = prop.GetValue("StartVisibleDown").ToString() == "True" ? true : false; } catch { }
                        try { _Property.ActionProperties.PauseVisibleUp = prop.GetValue("PauseVisibleUp").ToString() == "True" ? true : false; } catch { }
                        try { _Property.ActionProperties.StopVisibleUp = prop.GetValue("StopVisibleUp").ToString() == "True" ? true : false; } catch { }
                        try { _Property.ActionProperties.PauseVisibleDown = prop.GetValue("PauseVisibleDown").ToString() == "True" ? true : false; } catch { }
                        try { _Property.ActionProperties.StopVisibleDown = prop.GetValue("StopVisibleDown").ToString() == "True" ? true : false; } catch { }
                        try { _Property.ActionProperties.StartEnabledBoth = prop.GetValue("StartEnabledBoth").ToString() == "True" ? true : false; } catch { }
                        try { _Property.ActionProperties.StartEnabledUp = prop.GetValue("StartEnabledUp").ToString() == "True" ? true : false; } catch { }
                        try { _Property.ActionProperties.StartEnabledDown = prop.GetValue("StartEnabledDown").ToString() == "True" ? true : false; } catch { }
                        try { _Property.ActionProperties.PauseEnabledUp = prop.GetValue("PauseEnabledUp").ToString() == "True" ? true : false; } catch { }
                        try { _Property.ActionProperties.StopEnabledUp = prop.GetValue("StopEnabledUp").ToString() == "True" ? true : false; } catch { }
                        try { _Property.ActionProperties.PauseEnabledDown = prop.GetValue("PauseEnabledDown").ToString() == "True" ? true : false; } catch { }
                        try { _Property.ActionProperties.StopEnabledDown = prop.GetValue("StopEnabledDown").ToString() == "True" ? true : false; } catch { }
                        try { _Property.ActionProperties.Mode = (mode)Enum.Parse(typeof(mode), prop.GetValue("Mode").ToString()); } catch { }
                        try { _Property.ActionProperties.Text = prop.GetValue("Text").ToString(); } catch { }
                        try { _Property.ActionProperties.Type = (type)Enum.Parse(typeof(type), _Property.Type.ToString()); } catch { }
                        try { _Property.ActionProperties.StateUP = (state)Enum.Parse(typeof(state), prop.GetValue("State").ToString()); } catch { }

                        try { _Property.ActionProperties.Schedule.Interval = Convert.ToInt32(prop.GetValue("Interval").ToString()); } catch { }
                        try { _Property.ActionProperties.Schedule.IntervalUnit = (intervalUnit)Enum.Parse(typeof(intervalUnit), prop.GetValue("Unit").ToString()); } catch { }
                        try { _Property.ActionProperties.Schedule.ScheduleDate = Convert.ToDateTime(prop.GetValue("ScheduleDate").ToString()); } catch { }
                        try { _Property.ActionProperties.Schedule.IntMode = (IntervalMode)Enum.Parse(typeof(IntervalMode), prop.GetValue("IntMode").ToString()); } catch { }
                        try { _Property.ActionProperties.Buffer = Convert.ToInt32(prop.GetValue("Buffer")); } catch { }
                      
                        _Properties.Add(_Property);
                    }
                    catch
                    {
                        return null;
                    }
                    finally
                    {

                    }
                    //}
                }
            }
            catch
            {
                return null;
            }
            _Nodes.Clear();
            _Nodes = _Properties;
            return _Properties;
        }
    }
}
