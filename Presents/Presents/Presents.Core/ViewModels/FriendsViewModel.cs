
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Presents.Core.Domain;
using Presents.Core.IServices;

namespace Presents.Core.ViewModels
{
    public class FriendsViewModel : BaseViewModel
    {
        private List<ListItem> list=new List<ListItem>();

        public FriendsViewModel()
        {
            
         
        }

        public async void Init()
        {
            IGetProfileService profileService;
            Mvx.TryResolve(out profileService);

            var users = await profileService.GetFriends();

            var s = users.items.Select(friend => new ListItem(friend.first_name +" "+ friend.last_name, friend.photo_100)).ToList();
            Items = new List<ListItem>(s);
        }

        public List<ListItem> Items
        {
            set
            {
                list = value;
                RaisePropertyChanged(() => Items);
            }
            get
            {
                //он на каждый гет булет вызывать этот метод, ткак как  гет даже при пролистывании листвью ьбудет вызываться
               // InitializeMyList();
                return list;
            }
        }

        private async void InitializeMyList()
        {
            list = new List<ListItem>();
            IGetProfileService getProfileService;
            var service = Mvx.TryResolve(out getProfileService);
            
            var friends = await getProfileService.GetFriends();
            foreach (var friend in friends.items)
            {
                list.Add(new ListItem(friend.first_name, friend.photo_100));
            }
        }


        private List<ListItem> _selectedItems;
        public List<ListItem> SelectedItems
        {
            get
            {
                if (_selectedItems == null)
                    _selectedItems = new List<ListItem>();
                return _selectedItems;
            }
            set { _selectedItems = value; RaisePropertyChanged(() => SelectedItems); }
        }
        public IMvxCommand OnItemSelectCommand
        {
            get { return new MvxCommand<ListItem>(OnItemSelect); }
        }
        public void OnItemSelect(ListItem item)
        {
            if (SelectedItems.Contains(item))
            {
                SelectedItems.Remove(item);
            }
            else
            {
                SelectedItems.Add(item);
            }
            RaisePropertyChanged(() => SelectedItems);
        }
    }

    public class ListItem
    {
        public ListItem(string title, string photo) : base()
        {
            this.Title = title;
            this.Photo = photo;
        }

        public string Title { get; set; }
        public string Photo { get; set; }
    }
}
