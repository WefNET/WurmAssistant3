﻿namespace AldurSoft.WurmApi.DataModel.WurmServersModel
{
    public class WurmServerLogsData
    {
        public WurmServerLogsData()
        {
            TimeDetails = new TimeDetails();
        }

        public TimeDetails TimeDetails { get; set; }
    }
}