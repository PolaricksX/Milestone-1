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
    // CLASS: Event
    //        - An individual event for calendar program
    // ====================================================================

    /// <summary>
    /// Creates Events To allow the creation of CalendarItem.
    /// </summary>
    /// <exmaple>
    /// <code>
    /// <![CDATA[
    /// 
    /// Event Event = New Event(1,New DateTime(2026,2,27),90,"Went to the WaterPark",5)
    /// 
    /// Event.Id = 1
    /// Event.StartDateTime = "2026,2,27"
    /// Event.DurationInMinutes = 90
    /// Event.Details = "Went to the WaterPark
    /// ]]>
    /// </code>
    /// </exmaple>
    public class Event
    {
        // ====================================================================
        // Properties
        // ====================================================================

        /// <summary>
        /// Gets The Id Assigned to the event and returns it.
        /// </summary>
        /// <value>
        /// Stores an Id which is an integer value.
        /// </value>
        public int Id { get; }

        /// <summary>
        /// Gets The Start Date And Time When the event occured
        /// </summary>
        /// <value>
        /// Stores The Date In YYYY/MM/DD Format
        /// </value>
        public DateTime StartDateTime { get;  }
        
        /// <summary>
        /// Gets Or Sets the duration Of the Event measured in minutes.
        /// </summary>
        /// <value>
        /// Stores the Duration of the event in minutes.
        /// </value>
        public Double DurationInMinutes { get; set; }

        /// <summary>
        /// Gets or Sets the Description/Details of the event
        /// </summary>
        /// <value>Stores the Description/Details of the event as a a string</value>
        public String Details { get; set; }

        /// <summary>
        /// Gets or Sets the Category as an integer number which associates to an already predefined category.
        /// </summary>
        /// <value>
        /// Stores an integer value which represents a category.
        /// </value>
        public int Category { get; set; }

        // ====================================================================
        // Constructor
        //    NB: there is no verification the event category exists in the
        //        categories object
        // ====================================================================

        /// <summary>
        /// Creates an Instance of Event
        /// </summary>
        /// <param name="id">The Id of the event</param>
        /// <param name="date">The Date the event Occured in YYYY/MM/DD Format</param>
        /// <param name="category">The Category the Event is classified as.</param>
        /// <param name="duration">The Duration of the Event measured in minutes.</param>
        /// <param name="details">The Details/Description of the event</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// 
        /// Event Event = New Event(1,New DateTime(2026,2,27),90,"Went to the WaterPark",5)
        /// 
        /// Event.Id = 1
        /// Event.StartDateTime = "2026,2,27"
        /// Event.DurationInMinutes = 90
        /// Event.Details = "Went to the WaterPark
        /// 
        /// 
        /// ]]>
        /// </code>
        /// </example>
        public Event(int id, DateTime date, int category, Double duration, String details)
        {
            this.Id = id;
            this.StartDateTime = date;
            this.Category = category;
            this.DurationInMinutes = duration;
            this.Details = details;
        }

        // ====================================================================
        // Copy constructor - does a deep copy
        // ====================================================================

        /// <summary>
        /// Creates An Copy of an instance depending on the passed in Object.
        /// </summary>
        /// <param name="obj">The object to Copy</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// Event Event = New Event(1,New DateTime(2026,2,27),90,"Went to the WaterPark",5)
        /// 
        /// Event CopyEvent(Event)
        /// 
        /// CopyEvent.Id = 1
        /// CopyEvent.StartDateTime = "2026,2,27"
        /// CopyEvent.DurationInMinutes = 90
        /// CopyEvent.Details = "Went to the WaterPark"
        /// ]]>
        /// </code>
        /// </example>
        public Event (Event obj)
        {
            this.Id = obj.Id;
            this.StartDateTime = obj.StartDateTime;
            this.Category = obj.Category;
            this.DurationInMinutes = obj.DurationInMinutes;
            this.Details = obj.Details;
           
        }
    }
}
