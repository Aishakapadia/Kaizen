using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UFS_Application.App_class
{
    public class MisOp
    {
        public enum FormStatus
        {
            VIEW,
            EDIT,
            ADD,
            ACTION
        }
        public enum ApprovalStatus
        {
            Created = 0,
            Pending = 1,
            Reject = 2,
            Approved = 3,
            Terminate = 4
        }
        public enum AccountTypes
        {
            AM = 1,
            TM = 1,
            GSM = 2,
            FBP = 3,
            MF = 4,
            CH = 5,
            MIS = 10
        }
        public enum GridCommand
        {
            GRIDDOWNLOAD,
            GRIDEDIT,
            GRIDDELETE,
            QUALIFICATIONDELETE,
            QUALIFICATIONEDIT,
            GRIDAPPROVED,
            GRIDREJECT,
            GRIDAPPLY,
            GRIDVIEWMEMBER,
            GRIDSHORTLIST,
            GRIDCONFIRM,
            GRIDVIEW,
            GRIDACTION
        }
        public enum SessionNames
        {
            S_User
        }
        public enum enum_regions
        {
            NORTH,
            SOUTH,
            WEST,
            EAST,
            CENTRAL,
            NONE,
            REGIONHEAD,
            FBR,
            MF,
            CHUFS

        }

    }
}