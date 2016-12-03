using System.Collections.Generic;
using System.Linq;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Presents.Core.IServices;

namespace Presents.Core.ViewModels
{
    public class FriendsViewModel : BaseViewModel
    {
        private List<ListItem> _selectedItems;
        private List<ListItem> list = new List<ListItem>();

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

        public List<ListItem> SelectedItems
        {
            get
            {
                if (_selectedItems == null)
                    _selectedItems = new List<ListItem>();
                return _selectedItems;
            }
            set
            {
                _selectedItems = value;
                RaisePropertyChanged(() => SelectedItems);
            }
        }

        public IMvxCommand OnItemSelectCommand
        {
            get { return new MvxCommand<ListItem>(OnItemSelect); }
        }

        public async void Init()
        {
            IGetProfileService profileService;
            Mvx.TryResolve(out profileService);

            var users = await profileService.GetFriends();

            var s =
                users.items.Select(
                    friend => new ListItem(friend.first_name + " " + friend.last_name, friend.photo_50, friend.id))
                    .ToList();
            Items = new List<ListItem>(s);
        }

        private async void InitializeMyList()
        {
            list = new List<ListItem>();
            IGetProfileService getProfileService;
            var service = Mvx.TryResolve(out getProfileService);

            var friends = await getProfileService.GetFriends();
            foreach (var friend in friends.items)
            {
                list.Add(new ListItem(friend.first_name, friend.photo_50, friend.id));
            }
        }

        public void OnItemSelect(ListItem item)
        {
            ShowViewModel<FriendViewModel>(new {idFriend = item.Id});
            //if (SelectedItems.Contains(item))
            //{
            //    SelectedItems.Remove(item);
            //}
            //else
            //{
            //    SelectedItems.Add(item);
            //}
            RaisePropertyChanged(() => SelectedItems);
        }
    }

    public class ListItem
    {
        public ListItem(string title, string photo, int id)
        {
            Title = title;
            Photo = photo;
            Id = id;
        }

        public string Title { get; set; }
        public int Id { get; set; }
        public string Photo { get; set; }
    }
}