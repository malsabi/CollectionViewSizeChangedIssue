namespace CollectionViewSizeChangedIssue
{
    public class ResponsiveGridBehavior : Behavior<CollectionView>
    {
        protected override void OnAttachedTo(CollectionView bindable)
        {
            base.OnAttachedTo(bindable);
            if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
                bindable.SizeChanged += OnSizeChanged;
        }

        protected override void OnDetachingFrom(CollectionView bindable)
        {
            if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
                bindable.SizeChanged -= OnSizeChanged;
            base.OnDetachingFrom(bindable);
        }

        private void OnSizeChanged(object? sender, EventArgs e)
        {
            if (sender is CollectionView collectionView && collectionView.ItemsLayout is GridItemsLayout gridItemsLayout)
            {
                double maxWidthPerItem = 300;
                gridItemsLayout.Span = Math.Max(1, (int)(collectionView.Width / maxWidthPerItem));
            }
        }
    }
}