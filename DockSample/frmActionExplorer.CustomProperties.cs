using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ActionExplorer;

namespace DBSync
{
    public partial class frmActionExplorer
    {
        static ActionToolStrip _ActionDataSync;
        static ActionToolStrip _ActionDataSyncPayment;
        static ActionToolStrip _ActionDataSyncPaymentDirect;
        static ActionToolStrip _ActionDataSyncPaymentIndirect;
        static ActionToolStrip _ActionDataSyncPaymentFile;
        static ActionToolStrip _ActionDataSyncMembership;
        static ActionToolStrip _ActionDataSyncMembershipApplication;
        static ActionToolStrip _ActionDataSyncChangeAddress;
        static ActionToolStrip _ActionDataSyncMemberData;
        static ActionToolStrip _ActionDataSyncExamination;
        static ActionToolStrip _ActionDataSyncTechnicalActivities;
        static ActionToolStrip _ActionFileSyncMemberData;
        static ActionToolStrip _ActionFileSyncExamination;
        static ActionToolStrip _ActionFileSyncTechnicalActivities;
        static ActionToolStrip _ActionUISyncForthcommingEvents;
        static ActionToolStrip _ActionUISyncHighlights;

        public List<ActionToolStrip> ActionToolStrips = new List<ActionToolStrip>();
        public List<RegKyeDBSyncActionTreeNode> ActionProperies { get; set; }
        public static ActionToolStrip ActionDataSync { get => _ActionDataSync; set => _ActionDataSync = value; }
        public static ActionToolStrip ActionDataSyncPayment { get => _ActionDataSyncPayment; set => _ActionDataSyncPayment = value; }
        public static ActionToolStrip ActionDataSyncPaymentDirect { get => _ActionDataSyncPaymentDirect; set => _ActionDataSyncPaymentDirect = value; }
        public static ActionToolStrip ActionDataSyncPaymentIndirect { get => _ActionDataSyncPaymentIndirect; set => _ActionDataSyncPaymentIndirect = value; }
        public static ActionToolStrip ActionDataSyncPaymentFile { get => _ActionDataSyncPaymentFile; set => _ActionDataSyncPaymentFile = value; }
        public static ActionToolStrip ActionDataSyncMembership { get => _ActionDataSyncMembership; set => _ActionDataSyncMembership = value; }
        public static ActionToolStrip ActionDataSyncMembershipApplication { get => _ActionDataSyncMembershipApplication; set => _ActionDataSyncMembershipApplication = value; }
        public static ActionToolStrip ActionDataSyncChangeAddress { get => _ActionDataSyncChangeAddress; set => _ActionDataSyncChangeAddress = value; }
        public static ActionToolStrip ActionDataSyncMemberData { get => _ActionDataSyncMemberData; set => _ActionDataSyncMemberData = value; }
        public static ActionToolStrip ActionDataSyncExamination { get => _ActionDataSyncExamination; set => _ActionDataSyncExamination = value; }
        public static ActionToolStrip ActionDataSyncTechnicalActivities { get => _ActionDataSyncTechnicalActivities; set => _ActionDataSyncTechnicalActivities = value; }
        public static ActionToolStrip ActionFileSyncMemberData { get => _ActionFileSyncMemberData; set => _ActionFileSyncMemberData = value; }
        public static ActionToolStrip ActionFileSyncExamination { get => _ActionFileSyncExamination; set => _ActionFileSyncExamination = value; }
        public static ActionToolStrip ActionFileSyncTechnicalActivities { get => _ActionFileSyncTechnicalActivities; set => _ActionFileSyncTechnicalActivities = value; }
        public static ActionToolStrip ActionUISyncForthcommingEvents { get => _ActionUISyncForthcommingEvents; set => _ActionUISyncForthcommingEvents = value; }
        public static ActionToolStrip ActionUISyncHighlights { get => _ActionUISyncHighlights; set => _ActionUISyncHighlights = value; }

        RegKyeDBSyncActionTreeNode node;
    }
}
