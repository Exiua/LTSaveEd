package LTSaveEd.Components;

import javafx.application.Platform;
import javafx.beans.Observable;
import javafx.beans.property.BooleanProperty;
import javafx.beans.property.ObjectProperty;
import javafx.beans.property.SimpleBooleanProperty;
import javafx.beans.property.SimpleObjectProperty;
import javafx.beans.value.ObservableValue;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.collections.transformation.FilteredList;
import javafx.event.Event;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Control;
import javafx.scene.control.ListView;
import javafx.scene.control.skin.ComboBoxListViewSkin;
import javafx.scene.input.KeyCode;
import javafx.scene.input.KeyEvent;
import javafx.util.StringConverter;

import java.util.List;

public class AutoCompleteComboBox {

    public static class HideableItem<T> {

        private final ObjectProperty<T> object = new SimpleObjectProperty<>();
        private final BooleanProperty hidden = new SimpleBooleanProperty();
        private StringConverter<HideableItem<T>> converter;

        public HideableItem(T object, StringConverter<HideableItem<T>> converter) {
            setConverter(converter);
            setObject(object);

        }

        private ObjectProperty<T> objectProperty() {
            return this.object;
        }

        public T getObject() {
            return this.objectProperty().get();
        }

        private void setObject(T object) {
            this.objectProperty().set(object);
        }

        private BooleanProperty hiddenProperty() {
            return this.hidden;
        }

        private boolean isVisible() {
            return !this.hiddenProperty().get();
        }

        private void setHidden(boolean hidden) {
            this.hiddenProperty().set(hidden);
        }

        private void setConverter(StringConverter<HideableItem<T>> converter) {
            this.converter = converter;
        }

        @Override
        public String toString() {
            return getObject() == null ? null : converter.toString(this);
        }
    }

    public static <T> ComboBox<HideableItem<T>> createComboBoxWithAutoCompletionSupport(List<T> items, StringConverter<HideableItem<T>> converter) {
        ObservableList<HideableItem<T>> hideableHideableItems = FXCollections.observableArrayList(hideableItem -> new Observable[]
                {
                        hideableItem.hiddenProperty()
                });

        for (T item : items) {
            HideableItem<T> hideableItem = new HideableItem<>(item, converter);
            hideableHideableItems.add(hideableItem);
        }

        FilteredList<HideableItem<T>> filteredHideableItems = new FilteredList<>(hideableHideableItems, t -> t.isVisible());

        ComboBox<HideableItem<T>> comboBox = new ComboBox<>();
        comboBox.setItems(filteredHideableItems);
        comboBox.setConverter(converter);

        ComboBoxListViewSkin<HideableItem<T>> comboBoxListViewSkin = new ComboBoxListViewSkin<>(comboBox);
        comboBoxListViewSkin.getPopupContent().addEventFilter(KeyEvent.ANY, (KeyEvent event) ->
        {
            if (event.getCode() == KeyCode.SPACE) {
                event.consume();
            }
        });
        comboBox.setSkin(comboBoxListViewSkin);

        @SuppressWarnings("unchecked")
        HideableItem<T>[] selectedItem = (HideableItem<T>[]) new HideableItem[1];

        comboBox.addEventHandler(KeyEvent.KEY_PRESSED, event ->
        {
            if (!comboBox.isShowing() || event.isShiftDown() || event.isControlDown()) {
                return;
            }
            comboBox.setEditable(true);
            comboBox.getEditor().clear();
        });

        comboBox.showingProperty().addListener((ObservableValue<? extends Boolean> observable, Boolean oldValue, Boolean newValue) ->
        {
            if (newValue) {
                @SuppressWarnings("unchecked")
                ListView<HideableItem<T>> lv = (ListView<HideableItem<T>>) ((ComboBoxListViewSkin<?>) comboBox.getSkin()).getPopupContent();

                Platform.runLater(() ->
                {
                    if (selectedItem[0] == null) // first use
                    {
                        double cellHeight = ((Control) lv.lookup(".list-cell")).getHeight();
                        lv.setFixedCellSize(cellHeight);
                    }
                });

                lv.scrollTo(comboBox.getValue());
            }
            else {

                HideableItem<T> value = comboBox.getValue();
                if (value != null) {
                    selectedItem[0] = value;
                }

                comboBox.setEditable(false);
                if (value != null) {
                    Platform.runLater(() ->
                    {
                        comboBox.getSelectionModel().select(selectedItem[0]);
                        comboBox.setValue(selectedItem[0]);
                    });
                }

            }
        });

        comboBox.setOnHidden((Event event) ->
        {
            for (HideableItem<T> item : hideableHideableItems) {
                item.setHidden(false);
            }
        });
        comboBox.valueProperty().addListener((ObservableValue<? extends HideableItem<T>> obs, HideableItem<T> oldValue, HideableItem<T> newValue) ->
        {
            if (newValue == null) {
                for (HideableItem<T> item : hideableHideableItems) {
                    item.setHidden(false);
                }
            }
        });

        comboBox.getEditor().textProperty().addListener((ObservableValue<? extends String> obs, String oldValue, String newValue) ->
        {
            if (!comboBox.isShowing()) {
                return;
            }

            Platform.runLater(() ->
            {
                if (comboBox.getSelectionModel().getSelectedItem() == null) {
                    for (HideableItem<T> item : hideableHideableItems) {
                        item.setHidden(!item.toString().toLowerCase().contains(newValue.toLowerCase()));
                    }
                }
                else {

                    boolean validText = false;

                    for (HideableItem<T> hideableItem : hideableHideableItems) {
                        if (hideableItem.toString().equals(newValue)) {
                            validText = true;
                            break;
                        }
                    }

                    if (!validText) {
                        comboBox.getSelectionModel().select(null);
                    }
                }
            });
        });

        return comboBox;
    }

    public static <T> void addAutoCompleteToComboBox(ComboBox<T> comboBox, StringConverter<HideableItem<T>> converter) {
        ObservableList<HideableItem<T>> hideableItems = FXCollections.observableArrayList(hideableItem -> new Observable[]
                {
                        hideableItem.hiddenProperty()
                });

        var items = comboBox.getItems();

        for (T item : items) {
            HideableItem<T> hideableItem = new HideableItem<>(item, converter);
            hideableItems.add(hideableItem);
        }

        FilteredList<HideableItem<T>> filteredHideableItems = new FilteredList<>(hideableItems, t -> t.isVisible());

        @SuppressWarnings("unchecked")
        ComboBox<HideableItem<T>> moddedComboBox = (ComboBox<HideableItem<T>>) comboBox;
        moddedComboBox.setItems(filteredHideableItems);
        moddedComboBox.setConverter(converter);

        ComboBoxListViewSkin<HideableItem<T>> comboBoxListViewSkin = new ComboBoxListViewSkin<>(moddedComboBox);
        comboBoxListViewSkin.getPopupContent().addEventFilter(KeyEvent.ANY, (KeyEvent event) ->
        {
            if (event.getCode() == KeyCode.SPACE) {
                event.consume();
            }
        });
        moddedComboBox.setSkin(comboBoxListViewSkin);

        @SuppressWarnings("unchecked")
        HideableItem<T>[] selectedItem = (HideableItem<T>[]) new HideableItem[1];

        moddedComboBox.addEventHandler(KeyEvent.KEY_PRESSED, event ->
        {
            if (!moddedComboBox.isShowing() || event.isShiftDown() || event.isControlDown()) {
                return;
            }
            moddedComboBox.setEditable(true);
            moddedComboBox.getEditor().clear();
        });

        moddedComboBox.showingProperty().addListener((ObservableValue<? extends Boolean> observable, Boolean oldValue, Boolean newValue) ->
        {
            if (newValue) {
                @SuppressWarnings("unchecked")
                ListView<HideableItem<T>> lv = (ListView<HideableItem<T>>) ((ComboBoxListViewSkin<?>) moddedComboBox.getSkin()).getPopupContent();

                Platform.runLater(() ->
                {
                    if (selectedItem[0] == null) // first use
                    {
                        double cellHeight = ((Control) lv.lookup(".list-cell")).getHeight();
                        lv.setFixedCellSize(cellHeight);
                    }
                });

                lv.scrollTo(moddedComboBox.getValue());
            }
            else {

                HideableItem<T> value = moddedComboBox.getValue();
                if (value != null) {
                    selectedItem[0] = value;
                }

                moddedComboBox.setEditable(false);
                if (value != null) {
                    Platform.runLater(() ->
                    {
                        moddedComboBox.getSelectionModel().select(selectedItem[0]);
                        moddedComboBox.setValue(selectedItem[0]);
                    });
                }

            }
        });

        moddedComboBox.setOnHidden((Event event) ->
        {
            for (HideableItem<T> item : hideableItems) {
                item.setHidden(false);
            }
        });
        moddedComboBox.valueProperty().addListener((ObservableValue<? extends HideableItem<T>> obs, HideableItem<T> oldValue, HideableItem<T> newValue) ->
        {
            if (newValue == null) {
                for (HideableItem<T> item : hideableItems) {
                    item.setHidden(false);
                }
            }
        });

        moddedComboBox.getEditor().textProperty().addListener((ObservableValue<? extends String> obs, String oldValue, String newValue) ->
        {
            if (!moddedComboBox.isShowing()) {
                return;
            }

            Platform.runLater(() ->
            {
                if (moddedComboBox.getSelectionModel().getSelectedItem() == null) {
                    for (HideableItem<T> item : hideableItems) {
                        item.setHidden(!item.toString().toLowerCase().contains(newValue.toLowerCase()));
                    }
                }
                else {

                    boolean validText = false;

                    for (HideableItem<T> hideableItem : hideableItems) {
                        if (hideableItem.toString().equals(newValue)) {
                            validText = true;
                            break;
                        }
                    }

                    if (!validText) {
                        moddedComboBox.getSelectionModel().select(null);
                    }
                }
            });
        });

    }
}
