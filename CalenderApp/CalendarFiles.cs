using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// ============================================================================
// (c) Sandy Bultena 2018
// * Released under the GNU General Public License
// ============================================================================

namespace Calendar
{

    /// <summary>
    /// CalendarFiles class is used to manage the files used in the Calendar project
    /// </summary>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// CalenderFiles File = New CalenderFiles()
    /// 
    /// String FilePath = ".\Users\TestUser\AppData\Local\Calendar"
    /// String FileName = "calendar.txt"
    ///
    /// File.VerifyReadFromFileName(FilePath,FileName)
    /// File.VerifyWriteFromFileName(FilePath,FileName)
    /// ]]>
    /// </code>
    /// </example>
    public class CalendarFiles
    {
        private static String DefaultSavePath = @"Calendar\";
        private static String DefaultAppData = @"%USERPROFILE%\AppData\Local\";

        // ====================================================================
        // verify that the name of the file, or set the default file, and 
        // is it readable?
        // throws System.IO.FileNotFoundException if file does not exist
        // ====================================================================

        /// <summary>
        /// Verfies if the path to the file exists
        /// </summary>
        /// <param name="FilePath">Relative Path to the file</param>
        /// <param name="DefaultFileName">The Name of the file</param>
        /// <returns>Returns FilePah if Valid.</returns>
        /// <exception cref="FileNotFoundException">Throws when the filepath does not exist.</exception>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// String nullPath = null
        /// String fileName = "Calendar.txt"
        /// 
        /// CalenderFiles File = New CalenderFiles()
        /// 
        /// String returnPath = File.VerifyReadFromFileName(NullPath,FileName)
        /// Console.WriteLine(ReturnPath) = "%USERPROFILE%\\AppData\\Local\\" "Calendar\\" "Calendar.txt"
        /// 
        /// String fakePath =  ".\This\Drive\Does\Not\Exist"
        /// returnPath = File.VerifyReadFromFileName(FakePath,fileName)
        /// returnPath = FileNotFoundException "ReadFromFileException: FilePath (" + FakePath + ") Does not exist"
        /// 
        /// string realPath = "".\Users\TestUser\AppData\Local\Calendar""
        /// returnPath = File.VerifyReadFromFileName
        /// 
        /// ]]>
        /// </code>
        /// </example>
        public static String VerifyReadFromFileName(String? FilePath, String DefaultFileName)
        {

            // ---------------------------------------------------------------
            // if file path is not defined, use the default one in AppData
            // ---------------------------------------------------------------
            if (FilePath == null)
            {
                FilePath = Environment.ExpandEnvironmentVariables(DefaultAppData + DefaultSavePath + DefaultFileName);
            }

            // ---------------------------------------------------------------
            // does FilePath exist?
            // ---------------------------------------------------------------
            if (!File.Exists(FilePath))
            {
                throw new FileNotFoundException("ReadFromFileException: FilePath (" + FilePath + ") does not exist");
            }

            // ----------------------------------------------------------------
            // valid path
            // ----------------------------------------------------------------
            return FilePath;

        }

        // ====================================================================
        // verify that the name of the file, or set the default file, and 
        // is it writable
        // ====================================================================

        public static String VerifyWriteToFileName(String? FilePath, String DefaultFileName)
        {
            // ---------------------------------------------------------------
            // if the directory for the path was not specified, then use standard application data
            // directory
            // ---------------------------------------------------------------
            if (FilePath == null)
            {
                // create the default appdata directory if it does not already exist
                String tmp = Environment.ExpandEnvironmentVariables(DefaultAppData);
                if (!Directory.Exists(tmp))
                {
                    Directory.CreateDirectory(tmp);
                }

                // create the default Calendar directory in the appdirectory if it does not already exist
                tmp = Environment.ExpandEnvironmentVariables(DefaultAppData + DefaultSavePath);
                if (!Directory.Exists(tmp))
                {
                    Directory.CreateDirectory(tmp);
                }

                FilePath = Environment.ExpandEnvironmentVariables(DefaultAppData + DefaultSavePath + DefaultFileName);
            }

            // ---------------------------------------------------------------
            // does directory where you want to save the file exist?
            // ... this is possible if the user is specifying the file path
            // ---------------------------------------------------------------
            String? folder = Path.GetDirectoryName(FilePath);
            String delme = Path.GetFullPath(FilePath);
            if (!Directory.Exists(folder))
            {
                throw new Exception("SaveToFileException: FilePath (" + FilePath + ") does not exist");
            }

            // ---------------------------------------------------------------
            // can we write to it?
            // ---------------------------------------------------------------
            if (File.Exists(FilePath))
            {
                FileAttributes fileAttr = File.GetAttributes(FilePath);
                if ((fileAttr & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    throw new Exception("SaveToFileException:  FilePath(" + FilePath + ") is read only");
                }
            }

            // ---------------------------------------------------------------
            // valid file path
            // ---------------------------------------------------------------
            return FilePath;

        }



    }
}
