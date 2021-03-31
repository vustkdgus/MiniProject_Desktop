using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MahApps.Metro.Controls.Dialogs;

namespace WpfSMSApp.View.User
{
    /// <summary>
    /// MyAccount.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DeactiveUser : Page
    {
        public DeactiveUser()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                // 콤보박스 초기화
                List<string> comboValues = new List<string>
                {
                    "False", // 0, index 0
                    "True"   // 1, index 1                  
                };
                

                List<Model.User> user = Logic.DataAccess.GetUsers();
                this.DataContext = user;
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 EditAccount Loaded : {ex}");
                throw ex;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }



      

        private async void BtnDeactive_Click(object sender, RoutedEventArgs e)
        {

            if (GrdData.SelectedItem == null)
            {
                await Commons.ShowMessageAsync("오류", "비활성화할 사용자를 선택하세요.");
                return;
            }

            bool isValid = true; // 입력된 값이 모두 만족하는지 판별하는 플래그

            if (isValid)
            {
                try
                {
                    var user = GrdData.SelectedItem as Model.User;
                    user.UserActivated = false;

                    var result = Logic.DataAccess.SetUser(user);
                    if (result == 0)
                    {
                        await Commons.ShowMessageAsync("오류", "사용자 수정에 실패했습니다.");
                        return;
                        // 입력 안됨
                    }
                    else
                    {
                        // 정상입력
                        NavigationService.Navigate(new UserList());
                    }
                }
                catch (Exception ex)
                {
                    Commons.LOGGER.Error($"예외발생 : {ex}");
                }
            }
        }

        private void GrdData_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                // 선택된값이 입력창에 나오도록
                var user = GrdData.SelectedItem as Model.User;
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 GrdData_SelectedCellsChanged {ex}");
            }

        }
    }
}
