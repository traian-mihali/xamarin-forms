using Moq;
using NUnit.Framework;
using XamarinFormsApp.Pages;
using XamarinFormsApp.ViewModels;

namespace XamarinFormsApp.Tests
{
    public class PlaylistsViewModelTests
    {
        private PlaylistsViewModel _viewModel;
        private Mock<IPageService> _pageService;

        [SetUp]
        public void Setup()
        {
            _pageService = new Mock<IPageService>();
            _viewModel = new PlaylistsViewModel(_pageService.Object);
        }

        [Test]
        public void AddPlaylist_WhenCalled_TheNewPlaylistShouldBeInTheList()
        {
            _viewModel.AddPlaylistCommand.Execute(null);

            Assert.AreEqual(1, _viewModel.Playlists.Count);
        }

        [Test]
        public void SelectPlaylist_WhenCalled_TheSelectedItemShouldBeDeselected()
        {
            var playlist = new PlaylistViewModel();
            _viewModel.Playlists.Add(playlist);

            _viewModel.SelectPlaylistCommand.Execute(playlist);

            Assert.IsNull(_viewModel.SelectedPlaylist);
        }

        [Test]
        public void SelectPlaylist_WhenCalled_IsFavoritePlaylistPropertyIsToggled()
        {
            var playlist = new PlaylistViewModel();
            _viewModel.Playlists.Add(playlist);

            _viewModel.SelectPlaylistCommand.Execute(playlist);

            Assert.IsTrue(playlist.IsFavorite);
        }

        [Test]
        public void SelectPlaylist_WhenCalled_ShouldNavigateTheUserToPlaylistDetailPage()
        {
            var playlist = new PlaylistViewModel();
            _viewModel.Playlists.Add(playlist);
            _viewModel.SelectPlaylistCommand.Execute(playlist);

            _pageService.Verify(p => p.PushAsync(It.IsAny<PlaylistDetailPage>()));
        }
    }
}