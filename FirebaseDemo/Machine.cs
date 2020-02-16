﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace FirebaseDemo
{
    [FirestoreData]
    public class Machine
    {
        [FirestoreDocumentId]
        public string ReferenceId { get; set; }

        [FirestoreDocumentCreateTimestamp]
        public Timestamp CreateTime { get; set; }

        [FirestoreDocumentUpdateTimestamp]
        public Timestamp UpdateTime { get; set; }

        [FirestoreDocumentReadTimestamp]
        public Timestamp ReadTime { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }

        [FirestoreProperty]
        public string Ip { get; set; }

        [FirestoreProperty]
        public string MachineName { get; set; }

        [FirestoreProperty]
        public Tool Tool { get; set; }

        [FirestoreProperty]
        public ExecutionData ExecutationData { get; set; }

    }

    [FirestoreData]
    public class Tool
    {
        [FirestoreProperty]
        public string Name { get; set; }

        [FirestoreProperty]
        public string Number { get; set; }

        [FirestoreProperty]
        public string Length { get; set; }

        [FirestoreProperty]
        public string Radius { get; set; }

        [FirestoreProperty]
        public string Radius2 { get; set; }

        [FirestoreProperty]
        public string LengthOversize { get; set; }

        [FirestoreProperty]
        public string RadiusOversize { get; set; }

        [FirestoreProperty]
        public string ReplacmentToolNumber { get; set; }

        [FirestoreProperty]
        public string Time { get; set; }

        [FirestoreProperty]
        public string CurrentTime { get; set; }
    }

    [FirestoreData]
    public class ExecutionData
    {

        [FirestoreProperty]
        public string NCSpindleOverride { get; set; }

        [FirestoreProperty]
        public string NCFeedOveride { get; set; }

        [FirestoreProperty]
        public string PLCSpindleOverride { get; set; }

        [FirestoreProperty]
        public string PLCFeedOverride { get; set; }

        [FirestoreProperty]
        public string PalletNumber { get; set; }

        [FirestoreProperty]
        public string ProgramStatus { get; set; }

        [FirestoreProperty]
        public string SelectedProgram { get; set; }

        [FirestoreProperty]
        public string ActiveProgram { get; set; }

        [FirestoreProperty]
        public string BlockNumber { get; set; }

        [FirestoreProperty]
        public string ExecutionMode { get; set; }
    }

}
