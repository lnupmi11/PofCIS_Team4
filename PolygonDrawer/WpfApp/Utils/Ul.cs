using System.Windows;
using Microsoft.Win32;

namespace PolygonDrawer.Utils
{
    /// <summary>
    /// Represents support methods for interface.
    /// </summary>
    public class Ul
    {
        #region Information Message 
        private const string InformationMessage = "Загальне :\n" +
                "\t1) Для того щоб намалювати фігуру, виберіть її\n" +
                "\tв меню" +
                "\tта виберіть її колір.\n" +
                "\t2) Клікніть по полотні.\n" +
                "\t3) У вас з'явиться вікно.\n" +
                "\tВведіть туди розміри багатокутника.\n" +
                "\t4) Далі натисніть кнопку Send і у вас з'явиться\n" +
                "\tваш багатокутник.\n" +
                "\t5) Нажавши правою кнопкою миші по багатокутнику ви\n" +
                "\tзможете його пересунути. Потрібно після цього \n" +
                "\tклікнути по пототні ще один раз правою кнопкою\n" +
                "\tі фігура пересунеться в цю точку\n" +
                "File :\n" +
                "\tЩоб зберегти малюнок нажміть кнопку 'Save'.\n" +
                "\tЩоб зберегти малюнок в форматі \n" +
                "\tкартинки нажміть кнопку 'Save as'.\n" +
                "\tЩоб створити новий малюнок нажміть кнопку 'New'.\n" +
                "\tЩоб відкрити якусь зі своїх робіт, нажміть кнопку 'Open'\n" +
                "\tі виберіть відповідний файл.\n" +
                 "Shapes :\n" +
                "\tУ вас буде список намальованих вами фігур.\n" +
                "\tВи можете змінити її колір, посунути, або видалити.'\n";

        #endregion

        /// <summary>
        /// Shows information message.
        /// </summary>
        /// <returns>Information message.</returns>
        public static MessageBoxResult CreateInformationWindow()
        {
            string caption = "Information box";

            return MessageBox.Show(InformationMessage, caption, MessageBoxButton.OK);
        }

        /// <summary>
        /// Opens save dialog for file saving.
        /// </summary>
        /// <returns>Save dialog window.</returns>
        public static SaveFileDialog CreateSaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                RestoreDirectory = true,
                Filter = "XML file (*.xml)|*.xml",
                DefaultExt = "xml",
                CheckPathExists = true,
                Title = "Save",
                ValidateNames = true
            };

            return saveFileDialog;
        }

        /// <summary>
        /// Opens open dialog for file opening.
        /// </summary>
        /// <returns>Open dialog window.</returns>
        public static OpenFileDialog CreateOpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "XML file (*.xml)|*.xml",
                RestoreDirectory = true,
                CheckFileExists = true,
                CheckPathExists = true,
                Title = "Choose file"
            };

            return openFileDialog;
        }
    }
}
