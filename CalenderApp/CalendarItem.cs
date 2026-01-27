using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ============================================================================
// (c) Sandy Bultena 2018
// * Released under the GNU General Public License
// ============================================================================

namespace Calendar
{
    // ====================================================================
    // CLASS: CalendarItem
    //        A single calendar item, includes a Category and an Event
    // ====================================================================
    
    /// <summary>
    /// Represents a single scheduled Calender entry in the Calender entry.
    /// </summary>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// CalendarItem = new CalendarItem
    /// {
    ///     categoryId = 2,
    ///     eventID = 2,
    ///     StartDateTime = new DateTime(2026, 1, 26),
    ///     category = "fun"
    ///     shortDescription "Went to the beach",
    ///     durationInMinutes = 73
    ///     busyTime = 73
    /// }
    /// ]]>
    /// </code>
    /// </example>
    public class CalendarItem
    {
        public int CategoryID { get; set; }
        public int EventID { get; set; }
        public DateTime StartDateTime { get; set; }
        public String? Category { get; set; }
        public String? ShortDescription { get; set; }
        public Double DurationInMinutes { get; set; }
        public Double BusyTime { get; set; }

    }

    public class CalendarItemsByMonth
    {
        public String? Month { get; set; }
        public List<CalendarItem>? Items { get; set; }
        public Double TotalBusyTime { get; set; }
    }


    public class CalendarItemsByCategory
    {
        public String? Category { get; set; }
        public List<CalendarItem>? Items { get; set; }
        public Double TotalBusyTime { get; set; }

    }


}
