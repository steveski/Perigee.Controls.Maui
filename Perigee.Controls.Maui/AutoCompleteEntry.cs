using System.Collections;
using System.Collections.Specialized;

namespace Perigee.Controls.Maui;

public partial class AutoCompleteEntry : ContentView
{
    public static readonly BindableProperty ItemsSourceProperty = 
        BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), 
            typeof(AutoCompleteEntry), 
            null,
            propertyChanging: (b, o, n) => (b as AutoCompleteEntry).OnItemsSourceSetting(o as IEnumerable, n as IEnumerable),
            propertyChanged: (b, o, v) => (b as AutoCompleteEntry).OnItemsSourceSet());

    public IEnumerable ItemsSource {
        get => (IEnumerable)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }


    public static readonly BindableProperty ItemTemplateProperty =
        BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate),
            typeof(AutoCompleteEntry), 
            new DataTemplate(typeof(DefaultAutoCompleteEntryItemView)),
            propertyChanged: (b, o, n) => (b as AutoCompleteEntry).OnItemTemplateChanged());

    public DataTemplate ItemTemplate
    {
        get => (DataTemplate)GetValue(ItemTemplateProperty);
        set => SetValue(ItemTemplateProperty, value);
    }





    ////////////////////////////////////

    private VerticalStackLayout _root = new VerticalStackLayout { Spacing = 0 };

    public AutoCompleteEntry()
    {
        Content = _root;
    }


    protected virtual void OnItemsSourceSetting(IEnumerable oldValue, IEnumerable newValue)
    {
        if (oldValue is INotifyCollectionChanged oldItemsSource)
        {
            oldItemsSource.CollectionChanged -= OnItemsSourceChanged;
        }

        if (newValue is INotifyCollectionChanged newItemsSource)
        {
            newItemsSource.CollectionChanged += OnItemsSourceChanged;
        }
    }

    protected virtual void OnItemsSourceSet()
    {
        Render();
    }

    private protected virtual void OnItemsSourceChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
            {
                foreach (var item in e.NewItems)
                {
                    //_root.Children.Insert(e.NewStartingIndex, new TreeViewNodeView(item as IHasChildrenTreeViewNode, ItemTemplate, ArrowTheme));
                }
            }
                break;
            case NotifyCollectionChangedAction.Remove:
            {
                foreach (var item in e.OldItems)
                {
                    _root.Children.Remove(_root.Children.FirstOrDefault(x => (x as View).BindingContext == item));
                }
            }
                break;
            default:
                Render();
                break;
        }
    }

    protected virtual void OnItemTemplateChanged()
    {
        // TODO: Some optimizations
        // Eventually
        Render();
    }

    void Render()
    {
        _root.Children.Clear();

        if (ItemsSource == null)
        {
            return;
        }

        foreach (var item in ItemsSource)
        {
            //if (item is IHasChildrenTreeViewNode node)
            //{
            //    _root.Children.Add(new TreeViewNodeView(node, ItemTemplate, ArrowTheme));
            //}
        }
    }

    
}
