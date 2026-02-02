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
    // CLASS: Category
    //        - An individual category for Calendar program
    //        - Valid category types: Event,AllDayEvent,Holiday
    // ====================================================================

    /// <summary>
    /// Creates Categories for calendar Items   
    /// </summary>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Category cat = new Category(12, "Non Standard", Category.CategoryType.Event);
    /// 
    /// Console.Writeline(cat.ToString)
    /// ]]>
    /// </code>
    /// </example>
    public class Category
    {
        // ====================================================================
        // Properties
        // ====================================================================

        /// <summary>
        /// Gets or Sets the Id for a single category entry.
        /// </summary>
        /// <value>The integer value that the category holds</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or Sets the description for a single category entry
        /// </summary>
        /// <value>a string representation of the description for the category.</value>
        public String Description { get; set; }

        /// <summary>
        /// Represents the types of Category thats can exist  
        /// </summary>
        public CategoryType Type { get; set; }
        public enum CategoryType
        {
            /// <summary>
            /// Event represents just a normal event like going outside
            /// </summary>
            Event,
            /// <summary>
            /// AllDayEvent represents an event that takes up the entire day
            /// </summary>
            AllDayEvent,
            /// <summary>
            /// Holiday represents an event that is a holiday
            /// </summary>
            Holiday,
            /// <summary>
            /// Availibility represents when the event is free time.
            /// </summary>
            Availability
        };

        // ====================================================================
        // Constructor
        // ====================================================================
        
        /// <summary>
        /// Creates an instance of Category.
        /// </summary>
        /// <param name="id">The Id of the Category</param>
        /// <param name="description"> A Short Description of the category</param>
        /// <param name="type">The Type that the event associates with.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// Category = new Category(1,"work stuff",Event)
        /// 
        /// Category.Id = 1
        /// Category.Description = "Work stuff"
        /// Category.Type = Event
        /// ]]>
        /// </code>
        /// </example>
        public Category(int id, String description, CategoryType type = CategoryType.Event)
        {
            this.Id = id;
            this.Description = description;
            this.Type = type;
        }

        // ====================================================================
        // Copy Constructor
        // ====================================================================

        /// <summary>
        /// Creates a Copy of the most recent Instance of a Category
        /// </summary>
        /// <param name="category">An old instance of Category.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// Category = new Category(1,"work stuff",Event)
        /// 
        /// Category.Id = 1
        /// Category.Description = "Work stuff"
        /// Category.Type = Event
        /// 
        /// Category = new Category2(Category)
        /// 
        /// Category12.Id = 1
        /// Category2.Description = "Work stuff"
        /// Category2.Type = Event
        /// ]]>
        /// </code>
        /// </example>
        public Category(Category category)
        {
            this.Id = category.Id; ;
            this.Description = category.Description;
            this.Type = category.Type;
        }
        // ====================================================================
        // String version of object
        // ====================================================================
        /// <summary>
        /// Creates an Easy to read String for Reusabiltiy.
        /// </summary>
        /// <returns>Description: A Description of the Category</returns>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// Category = new Category(1,"work stuff",Event)
        /// 
        /// Console.WriteLine(Category.Tostring)
        /// 
        /// Output "Work Stuff"
        /// ]]>
        /// </code>
        /// </example>
        public override string ToString()
        {
            return Description;
        }

    }
}

