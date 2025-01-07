using System.Windows.Forms;

namespace MarkingTemplate
{
    public class Navigation
    {
        public void NavigateTabs(int i, TabControl tabControl1)
        {
            var tabIndex = tabControl1.SelectedIndex;

            var newIndex = tabIndex + i; //Adds 1 for next & -1 for previous tab

            // Ensure the new index is within bounds
            if (newIndex >= 0 && newIndex < tabControl1.TabCount)
            {
                tabControl1.SelectedIndex = newIndex;
            }
        }
    }
}