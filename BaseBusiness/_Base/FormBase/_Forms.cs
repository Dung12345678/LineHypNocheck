using System;
using System.Windows.Forms;
namespace BMS
{
	public partial class _Forms : Form
	{
		#region Thông tin liên quan đến Security
		/// <summary>
		/// Permission[0] : _View_Right - Permission[1] : _Create_Right - Permission[2] : _Modify_Right - Permission[3] : _Delete_Right - Permission[4] : _Spencial_Right 
		/// </summary>
		public bool[] Permission;
		public bool _SEC_CHECK_VIEW()
		{
			//if ((Permission==null) || (Permission[0] == false))
			//    MessageBox.Show("You have not permission,please contact administrator.", "Message");
			return true;
		}
		public bool _SEC_CHECK_INSERT()
		{
			//if ((Permission==null) || (Permission[1] == false))
			//    MessageBox.Show("You have not permission,please contact administrator.", "Message");
			//return Permission[1];
			return true;
		}
		public bool _SEC_CHECK_MODIFY()
		{
			//if ((Permission == null) || (Permission[2] == false))
			//    MessageBox.Show("You have not permission,please contact administrator.", "Message");
			//return Permission[2];
			return true;
		}
		public bool _SEC_CHECK_DELETE()
		{
			//if ((Permission == null) || (Permission[3] == false))
			//    MessageBox.Show("You have not permission,please contact administrator.", "Message");
			//return Permission[3];
			return true;
		}
		public bool _SEC_CHECK_SPECIAL()
		{
			//if ((Permission == null) || (Permission[4] == false))
			//    MessageBox.Show("You have not permission,please contact administrator.", "Message");
			//return Permission[4];
			return true;
		}
		//Type myTypes=null;
		public _Forms()
		{
			InitializeComponent();
			//BindingFlags flags = (BindingFlags.NonPublic | BindingFlags.Public |BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly);
			//myTypes = this.GetType();

		}

		//public void ProcessFunctionKey(string _FunctionName,Object[] _Params)
		//{
		//    MethodInfo[] MIS = myTypes.GetMethods();
		//    foreach (MethodInfo Mi in MIS)
		//    {
		//        if (Mi.Name.Equals(_FunctionName))
		//        {
		//            Object obj = Activator.CreateInstance(myTypes);
		//            Object response = Mi.Invoke(obj, _Params);
		//            //result = (bool)response;

		//            break;
		//        }
		//    }
		//}
		#endregion

		#region Các sụ kiện liên quan đến phím tắt.
		//protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		//{
		//    bool handled = false;
		//    ShortcutKey.LoadFormShortcutKey(this, keyData.ToString(), ref handled);
		//    return (handled || base.ProcessCmdKey(ref msg, keyData));
		//}
		#endregion

		#region Load quyền
		private void _Forms_Load(object sender, EventArgs e)
		{
			//Permissions.LoadFormPermission(this);
		}
		#endregion

		private FormWindowState _VisibleFormState;

		public FormWindowState VisibleFormState
		{
			get { return _VisibleFormState; }
		}

		private void _Forms_Resize(object sender, EventArgs e)
		{
			if (this.WindowState != FormWindowState.Minimized)
				_VisibleFormState = this.WindowState;
		}



	}
}