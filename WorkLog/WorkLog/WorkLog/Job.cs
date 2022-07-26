using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace WorkLog
{
    [Table("job")]
    public class Job
    {
        // PrimaryKey is typically numeric 
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string NameOfJob { get; set; }
        public bool OddHours { get; set; }
        public DateTime DateOfJob { get; set; }
        public int DurationMins { get; set; }
        public int DurationHours { get; set; }
        public string TimeString { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", NameOfJob,
                CreateTimeString(DurationMins, DurationHours), DateOfJob.ToShortDateString(), OddHours ? "odd hours" : "regular hours");
        }

        public string CreateTimeString(int min, int hours)
        {
            int overFlowHours = (min - (min % 60)) / 60;
            int realMins = (min % 60);

            string hoursString   = (hours + overFlowHours).ToString().PadLeft(2, '0');
            string minutesString = (realMins).ToString().PadLeft(2, '0');

            return (hoursString + ":" + minutesString + ":00");
        }
    }
    public class JobsDatabaseCreation
    {
        public static void CreateDB(SQLiteConnection conn)
        {
            conn.CreateTable<Job>();
            //conn.DeleteAll<Job>();
        }
    }
}