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
        /// <summary>
        /// Gets or Sets the CategoryId Number of a calendar entry.
        /// </summary>
        /// <value> An integer value that is used to determined an already predefined category.</value>
        public int CategoryID { get; set; }
        /// <summary>
        /// Gets or Sets the EventId number of a calendar entry
        /// </summary
        /// <value>An integer value that is used to an already determined an already predefined event.</value>
        public int EventID { get; set; }
        /// <summary>
        /// Gets or Sets the Date of a calendar entry.
        /// </summary>
        /// <value> The date and time when the event started in DD/MM/YYYY</value>
        public DateTime StartDateTime { get; set; }
        /// <summary>
        /// Gets or Sets the Category of a calendar entry.
        /// </summary>
        /// <value>A string of the chosen Category like Holiday,Work</value>
        public String? Category { get; set; }
        /// <summary>
        /// Gets or sets a short description of a calendar entry.
        /// </summary>
        /// <value>a brief description of the event that occured.</value>
        public String? ShortDescription { get; set; }
        /// <summary>
        /// Gets or Sets the Duration of the event in minutes of a calendar entry.
        /// </summary>
        /// <value> The lenght of how long the event lasted measured in minutes. </value>
        public Double DurationInMinutes { get; set; }
        /// <summary>
        /// The Duration of the event in minutes of a calendar entry.
        /// </summary>
        /// <value> The lenght of how long the event lasted measured in minutes.</value>
        public Double BusyTime { get; set; }

    }
    /// <summary>
    /// Represents The total Events and busy time that took place in a month.
    /// </summary>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// CalendarItemsByMonth = new CalendarItemsByMonth
    /// {
    ///     Month = January
    ///     Items = new List<CalendarItem>
    ///     {
    ///         new CalendarItem
    ///         {
    ///             categoryId = 2,
    ///             eventID = 2,
    ///             StartDateTime = new DateTime(2026, 1, 26),
    ///             category = "fun"
    ///             shortDescription "Went to the beach",
    ///             durationInMinutes = 73
    ///             busyTime = 73
    ///         }
    ///     }
    ///     TotalBusyTime = 73
    /// }
    /// ]]>
    /// </code>
    /// </example>
    public class CalendarItemsByMonth
    {
        /// <summary>
        /// Get or sets The Month that the event took place in.
        /// </summary>
        /// <value> A month out of the twelve months in the year.</value>
        public String? Month { get; set; }

        /// <summary>
        /// Gets or Sets A list of Events that took place in the month
        /// </summary>
        /// <value>A List of Calendar Items </value>
        public List<CalendarItem>? Items { get; set; }
        /// <summary>
        /// The Accumulation of time that all of the events took
        /// </summary>
        /// <value> A double value that measures the total time all of the events took combined.</value>
        public Double TotalBusyTime { get; set; }
    }

    /// <summary>
    /// Groups the Calendar Items By Category.
    /// </summary>
    /// <example>
    /// <code>
    /// <![CDATA[
    ///     /// CalendarItemsByMonth = new CalendarItemsByMonth
    /// {
    ///     Category = Fun
    ///     Items = new List<CalendarItem>
    ///     {
    ///         new CalendarItem
    ///         {
    ///             categoryId = 2,
    ///             eventID = 2,
    ///             StartDateTime = new DateTime(2026, 1, 26),
    ///             category = "fun"
    ///             shortDescription "Went to the beach",
    ///             durationInMinutes = 73
    ///             busyTime = 73
    ///         }
    ///     }
    ///     TotalBusyTime = 73
    /// }
    /// ]]>
    /// </code>
    /// </example>
    public class CalendarItemsByCategory
    {
        /// <summary>
        /// Gets or Sets the Category to filter and group the events.
        /// </summary>
        /// <value> a string of the Type of event that took place</value>
        public String? Category { get; set; }
        /// <summary>
        /// Gets or Sets the Filtered Items by category.
        /// </summary>
        /// <value>A list of items grouped by category.</value>
        public List<CalendarItem>? Items { get; set; }
        /// <summary>
        /// Gets or Sets the total BusyTime that the group event accumulated.
        /// </summary>
        /// <value> A double value that measures the total time all of the events took combined </value>
        public Double TotalBusyTime { get; set; }

    }


}
