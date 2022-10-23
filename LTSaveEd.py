import sys

from PyQt5 import QtCore, QtGui
from PyQt5.QtGui import QFont, QTextCursor
from PyQt5.QtWidgets import QApplication, QLineEdit, QWidget, QFormLayout, QPushButton, QHBoxLayout, QTabWidget, \
    QDesktopWidget, QTextEdit, QTableWidget, QTableWidgetItem, QLabel, QCheckBox, QFileDialog, QComboBox, QMessageBox, \
    QTextBrowser, QVBoxLayout, QMainWindow


class LTSaveEd(QMainWindow):
    def __init__(self):
        super().__init__()
        self.title: str = "LTSaveEd"
        self.version: str = "v2.0.0"
        # Window Settings
        self.x, self.y, self.w, self.h = 0, 0, 768, 432
        self.setGeometry(self.x, self.y, self.w, self.h)

        qtRectangle = self.frameGeometry()
        centerPoint = QDesktopWidget().availableGeometry().center()
        qtRectangle.moveCenter(centerPoint)
        self.move(qtRectangle.topLeft())

        self.window = MainWindow(self)
        self.setCentralWidget(self.window)
        self.setWindowTitle(f"{self.title} {self.version}")  # Window Title
        self.show()


class CoreTab(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super(CoreTab, self).__init__(parent)
        layout = QVBoxLayout(self)

        hbox = QHBoxLayout()
        label = QLabel("Character:")
        combo_box = QComboBox()
        hbox.addWidget(label)
        hbox.addWidget(combo_box)
        layout.addLayout(hbox)

        layout.addStretch()


class AttributesTab(QWidget):
    def __init__(self, parent=None):
        super(AttributesTab, self).__init__(parent)
        lay = QVBoxLayout(self)
        hlay = QHBoxLayout()
        lay.addLayout(hlay)
        lay.addStretch()

        label_language = QLabel("Language")
        combo_language = QComboBox(self)
        combo_language.addItem("item1")
        combo_language.addItem("item2")
        hlay.addWidget(label_language)
        hlay.addWidget(combo_language)


class BodyTab(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super(BodyTab, self).__init__(parent)
        layout = QVBoxLayout(self)

        hbox = QHBoxLayout()
        label = QLabel("Character:")
        combo_box = QComboBox()
        hbox.addWidget(label)
        hbox.addWidget(combo_box)
        layout.addLayout(hbox)

        layout.addStretch()


class FetishesTab(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super(FetishesTab, self).__init__(parent)
        layout = QVBoxLayout(self)

        hbox = QHBoxLayout()
        label = QLabel("Character:")
        combo_box = QComboBox()
        hbox.addWidget(label)
        hbox.addWidget(combo_box)
        layout.addLayout(hbox)

        layout.addStretch()


class PerksTab(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super(PerksTab, self).__init__(parent)
        layout = QVBoxLayout(self)

        hbox = QHBoxLayout()
        label = QLabel("Character:")
        combo_box = QComboBox()
        hbox.addWidget(label)
        hbox.addWidget(combo_box)
        layout.addLayout(hbox)

        layout.addStretch()


class SpellsTab(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super(SpellsTab, self).__init__(parent)
        layout = QVBoxLayout(self)

        hbox = QHBoxLayout()
        label = QLabel("Character:")
        combo_box = QComboBox()
        hbox.addWidget(label)
        hbox.addWidget(combo_box)
        layout.addLayout(hbox)

        layout.addStretch()


class InventoryTab(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super(InventoryTab, self).__init__(parent)
        layout = QVBoxLayout(self)

        hbox = QHBoxLayout()
        label = QLabel("Character:")
        combo_box = QComboBox()
        hbox.addWidget(label)
        hbox.addWidget(combo_box)
        layout.addLayout(hbox)

        layout.addStretch()


class RelationshipsTab(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super(RelationshipsTab, self).__init__(parent)
        layout = QVBoxLayout(self)

        hbox = QHBoxLayout()
        label = QLabel("Character:")
        combo_box = QComboBox()
        hbox.addWidget(label)
        hbox.addWidget(combo_box)
        layout.addLayout(hbox)

        layout.addStretch()


class FamilyTab(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super(FamilyTab, self).__init__(parent)
        layout = QVBoxLayout(self)

        hbox = QHBoxLayout()
        label = QLabel("Character:")
        combo_box = QComboBox()
        hbox.addWidget(label)
        hbox.addWidget(combo_box)
        layout.addLayout(hbox)

        layout.addStretch()


class WorldTab(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super(WorldTab, self).__init__(parent)
        layout = QVBoxLayout(self)

        hbox = QHBoxLayout()
        label = QLabel("Character:")
        combo_box = QComboBox()
        hbox.addWidget(label)
        hbox.addWidget(combo_box)
        layout.addLayout(hbox)

        layout.addStretch()


class ExtraTab(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super(ExtraTab, self).__init__(parent)
        layout = QVBoxLayout(self)

        hbox = QHBoxLayout()
        label = QLabel("Character:")
        combo_box = QComboBox()
        hbox.addWidget(label)
        hbox.addWidget(combo_box)
        layout.addLayout(hbox)

        layout.addStretch()


class PregnancyTab(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super(PregnancyTab, self).__init__(parent)
        layout = QVBoxLayout(self)

        hbox = QHBoxLayout()
        label = QLabel("Character:")
        combo_box = QComboBox()
        hbox.addWidget(label)
        hbox.addWidget(combo_box)
        layout.addLayout(hbox)

        layout.addStretch()


class MainWindow(QWidget):
    def __init__(self, parent):
        super(MainWindow, self).__init__(parent)
        layout = QVBoxLayout(self)

        # Initialize tabs
        tab_widget = QTabWidget()
        core_tab = CoreTab()
        attributes_tab = AttributesTab()
        body_tab = BodyTab()
        fetishes_tab = FetishesTab()
        perks_tab = PerksTab()
        spells_tab = SpellsTab()
        inventory_tab = InventoryTab()
        relationships_tab = RelationshipsTab()
        family_tab = FamilyTab()
        world_tab = WorldTab()
        extra_tab = ExtraTab()
        pregnancy_tab = PregnancyTab()

        # Add tabs
        tab_widget.addTab(core_tab, "Core")
        tab_widget.addTab(attributes_tab, "Attributes")
        tab_widget.addTab(body_tab, "Body")
        tab_widget.addTab(fetishes_tab, "Fetishes")
        tab_widget.addTab(perks_tab, "Perks")
        tab_widget.addTab(spells_tab, "Spells")
        tab_widget.addTab(inventory_tab, "Inventory")
        tab_widget.addTab(relationships_tab, "Relationships")
        tab_widget.addTab(family_tab, "Family")
        tab_widget.addTab(world_tab, "World")
        tab_widget.addTab(extra_tab, "Extra")
        tab_widget.addTab(pregnancy_tab, "Pregnancy")
        tab_widget.setTabEnabled(11, False)

        layout.addWidget(tab_widget)


if __name__ == '__main__':
    app = QApplication(sys.argv)
    ex = LTSaveEd()
    sys.exit(app.exec_())
