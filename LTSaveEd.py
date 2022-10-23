import sys

from PyQt5 import QtCore, QtGui
from PyQt5.QtGui import QFont, QTextCursor
from PyQt5.QtWidgets import QApplication, QLineEdit, QWidget, QFormLayout, QPushButton, QHBoxLayout, QTabWidget, \
    QDesktopWidget, QTextEdit, QTableWidget, QTableWidgetItem, QLabel, QCheckBox, QFileDialog, QComboBox, QMessageBox, \
    QTextBrowser


class LTSaveEd(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super().__init__(parent)


if __name__ == '__main__':
    app = QApplication(sys.argv)
    win = LTSaveEd()
    win.show()
    sys.exit(app.exec_())
