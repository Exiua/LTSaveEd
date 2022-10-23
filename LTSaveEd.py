import sys

from PyQt5 import QtCore, QtGui
from PyQt5.QtGui import QFont, QTextCursor
from PyQt5.QtWidgets import QApplication, QLineEdit, QWidget, QFormLayout, QPushButton, QHBoxLayout, QTabWidget, \
    QDesktopWidget, QTextEdit, QTableWidget, QTableWidgetItem, QLabel, QCheckBox, QFileDialog, QComboBox, QMessageBox, \
    QTextBrowser, QVBoxLayout


class LTSaveEd(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super().__init__(parent)
        # region Instance Variables

        self.title: str = "LTSaveEd"
        self.version: str = "v2.0.0"

        # endregion

        self.setGeometry(0, 0, 768, 432)

        qtRectangle = self.frameGeometry()
        centerPoint = QDesktopWidget().availableGeometry().center()
        qtRectangle.moveCenter(centerPoint)
        self.move(qtRectangle.topLeft())

        # region UI Construction

        tab_widget = QTabWidget()

        # region Tab Creation

        # region Core Tab

        core_tab = QWidget()
        vbox = QVBoxLayout(core_tab)
        hbox = QHBoxLayout()
        label = QLabel("Id:")
        self.core_id_value = QLineEdit()
        hbox.addWidget(label)
        hbox.addWidget(self.core_id_value)
        vbox.addLayout(hbox)

        # endregion

        # region Attributes Tab

        attributes_tab = QWidget()

        # endregion

        # region Body Tab

        body_tab = QWidget()

        # endregion

        # region Fetishes Tab

        fetishes_tab = QWidget()

        # endregion

        # region Perks Tab

        perks_tab = QWidget()

        # endregion

        # region Spells Tab

        spells_tab = QWidget()

        # endregion

        # region Inventory Tab

        inventory_tab = QWidget()

        # endregion

        # region Relationships Tab

        relationships_tab = QWidget()

        # endregion

        # region Family Tab

        family_tab = QWidget()

        # endregion

        # region World Tab

        world_tab = QWidget()

        # endregion

        # region Extra Tab

        extra_tab = QWidget()

        # endregion

        # region Pregnancy Tab

        pregnancy_tab = QWidget()

        # endregion

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

        # endregion

        form_layout = QFormLayout()
        form_layout.addRow(tab_widget)
        self.setLayout(form_layout)
        self.setWindowTitle(f"{self.title} {self.version}")

        # endregion


if __name__ == '__main__':
    app = QApplication(sys.argv)
    win = LTSaveEd()
    win.show()
    sys.exit(app.exec_())
