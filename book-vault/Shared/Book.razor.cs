using book_vault.Models;
using Microsoft.AspNetCore.Components;

namespace book_vault.Shared
{
	public partial class Book
	{
		[Parameter]
		public BookModel? BookModel { get; set; }
		[Parameter]
		public Action? OnRemoveBookAsync { get; set; }
		[Parameter]
		public Action? OnCloseUpdateModal { get; set; }
		private bool RemoveBookModalIsVisible { get; set; } = false;
		private bool UpdateBookModalIsVisible { get; set; } = false;

		protected override void OnInitialized()
		{
			RemoveBookModalIsVisible = false;
			UpdateBookModalIsVisible = false;
		}

		private void ToggleRemoveBookModal()
		{
			RemoveBookModalIsVisible = !RemoveBookModalIsVisible;

			StateHasChanged();
		}

		private void ToggleUpdateBookModal()
		{
			UpdateBookModalIsVisible = !UpdateBookModalIsVisible;

			StateHasChanged();
		}

		private void CloseUpdateModal()
		{
			UpdateBookModalIsVisible = false;

			OnCloseUpdateModal?.Invoke();
		}

		private void RemoveBookAsync()
		{
			BookModel = null;

			RemoveBookModalIsVisible = false;

			OnRemoveBookAsync?.Invoke();
		}
	}
}
