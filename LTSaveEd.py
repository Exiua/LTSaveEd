import sys
from typing import Type

from PyQt5 import QtCore, QtGui
from PyQt5.QtGui import QFont, QTextCursor, QIntValidator, QValidator
from PyQt5.QtWidgets import QApplication, QLineEdit, QWidget, QFormLayout, QPushButton, QHBoxLayout, QTabWidget, \
    QDesktopWidget, QTextEdit, QTableWidget, QTableWidgetItem, QLabel, QCheckBox, QFileDialog, QComboBox, QMessageBox, \
    QTextBrowser, QVBoxLayout, QMainWindow, QPlainTextEdit

# region Globals

int_only = QIntValidator()
positive_int_only = QIntValidator()
positive_int_only.setBottom(0)


# endregion


class LTSaveEd(QMainWindow):
    def __init__(self):
        super().__init__()
        self.title: str = "LTSaveEd"
        self.version: str = "v2.0.0"
        # Window Settings
        self.x, self.y, self.w, self.h = 0, 0, 1024, 700
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
        layout = QHBoxLayout(self)

        # region Left VBox

        left_vbox = QVBoxLayout()

        hbox = QHBoxLayout()
        label = QLabel("Character:")
        self.character_selector = QComboBox()
        self.character_selector.setFixedWidth(150)
        self.delete_character = QPushButton("Delete Character")
        self.delete_character.setStyleSheet("color: #FF0000")
        hbox.addWidget(label)
        hbox.addWidget(self.character_selector)
        hbox.addWidget(self.delete_character)
        hbox.addStretch()
        left_vbox.addLayout(hbox)

        hbox, self.core_id_value = create_labeled_line_edit("Id:")
        left_vbox.addLayout(hbox)

        hbox = QHBoxLayout()
        label = QLabel("Name (A, F, M):")
        self.core_name_nameAndrogynous = QLineEdit()
        self.core_name_nameFeminine = QLineEdit()
        self.core_name_nameMasculine = QLineEdit()
        self.core_name_nameAndrogynous.setFixedWidth(150)
        self.core_name_nameFeminine.setFixedWidth(150)
        self.core_name_nameMasculine.setFixedWidth(150)
        hbox.addWidget(label)
        hbox.addWidget(self.core_name_nameAndrogynous)
        hbox.addWidget(self.core_name_nameFeminine)
        hbox.addWidget(self.core_name_nameMasculine)
        hbox.addStretch()
        left_vbox.addLayout(hbox)

        hbox, self.core_surname_value = create_labeled_line_edit("Surname:")
        left_vbox.addLayout(hbox)

        hbox = QHBoxLayout()
        label = QLabel("Description:")
        self.core_description_value = QPlainTextEdit()
        self.core_description_value.setFixedWidth(475)
        self.core_description_value.setFixedHeight(78)
        hbox.addWidget(label)
        hbox.addWidget(self.core_description_value)
        hbox.addStretch()
        left_vbox.addLayout(hbox)

        hbox = QHBoxLayout()
        label = QLabel("Level:")
        self.core_level_value = QLineEdit()
        self.core_level_value.setFixedWidth(150)
        self.core_level_value.setValidator(positive_int_only)
        label2 = QLabel("Experience:")
        self.core_experience_value = QLineEdit()
        self.core_experience_value.setFixedWidth(150)
        self.core_experience_value.setValidator(positive_int_only)
        hbox.addWidget(label)
        hbox.addWidget(self.core_level_value)
        hbox.addWidget(label2)
        hbox.addWidget(self.core_experience_value)
        hbox.addStretch()
        left_vbox.addLayout(hbox)

        hbox, self.characterInventory_money_value = create_labeled_line_edit("Money:", validator=positive_int_only)
        left_vbox.addLayout(hbox)

        hbox = QHBoxLayout()
        label = QLabel("Date of Birth:")
        self.core_yearOfBirth_value = QLineEdit()
        self.core_yearOfBirth_value.setFixedWidth(150)
        self.core_monthOfBirth_value = QComboBox()
        self.core_monthOfBirth_value.setFixedWidth(150)  # TODO: Proper Validation
        self.core_dayOfBirth_value = QLineEdit()
        self.core_dayOfBirth_value.setFixedWidth(150)
        hbox.addWidget(label)
        hbox.addWidget(self.core_yearOfBirth_value)
        hbox.addWidget(self.core_monthOfBirth_value)
        hbox.addWidget(self.core_dayOfBirth_value)
        hbox.addStretch()
        left_vbox.addLayout(hbox)

        hbox = QHBoxLayout()
        label = QLabel("Job History:")
        self.core_history_value = QComboBox()
        self.core_history_value.setFixedWidth(150)
        hbox.addWidget(label)
        hbox.addWidget(self.core_history_value)
        hbox.addStretch()
        left_vbox.addLayout(hbox)

        hbox = QHBoxLayout()
        label = QLabel("Orientation:")
        self.core_sexualOrientation_value = QComboBox()
        self.core_sexualOrientation_value.setFixedWidth(150)
        hbox.addWidget(label)
        hbox.addWidget(self.core_sexualOrientation_value)
        hbox.addStretch()
        left_vbox.addLayout(hbox)

        hbox, self.core_obedience_value = create_labeled_line_edit("Obedience:", validator=positive_int_only)
        left_vbox.addLayout(hbox)

        hbox = QHBoxLayout()
        label = QLabel("Gender Identity:")
        self.core_genderIdentity_value = QComboBox()
        self.core_genderIdentity_value.setFixedWidth(200)
        hbox.addWidget(label)
        hbox.addWidget(self.core_genderIdentity_value)
        hbox.addStretch()
        left_vbox.addLayout(hbox)

        hbox, self.core_perkPoints_value = create_labeled_line_edit("Perk Points:", validator=positive_int_only)
        left_vbox.addLayout(hbox)

        hbox, self.characterInventory_essenceCount_value = create_labeled_line_edit("Essence Count:",
                                                                                    validator=positive_int_only)
        left_vbox.addLayout(hbox)

        hbox, self.core_health_value = create_labeled_line_edit("Health:", validator=positive_int_only)
        left_vbox.addLayout(hbox)

        hbox, self.core_mana_value = create_labeled_line_edit("Mana:", validator=positive_int_only)
        left_vbox.addLayout(hbox)

        left_vbox.addStretch()

        # endregion

        # region Right VBox

        right_vbox = QVBoxLayout()
        right_vbox.addStretch()

        hbox = QHBoxLayout()
        hbox.addStretch()
        label = QLabel("Personality:")
        hbox.addWidget(label)
        hbox.addStretch()
        right_vbox.addLayout(hbox)

        hbox = QHBoxLayout()
        hbox.addStretch()
        self.personalityTrait_CONFIDENT = QCheckBox("Confident")
        hbox.addWidget(self.personalityTrait_CONFIDENT)
        self.personalityTrait_SHY = QCheckBox("Shy")
        hbox.addWidget(self.personalityTrait_SHY)
        self.personalityTrait_KIND = QCheckBox("Kind")
        hbox.addWidget(self.personalityTrait_KIND)
        self.personalityTrait_SELFISH = QCheckBox("Selfish")
        hbox.addWidget(self.personalityTrait_SELFISH)
        self.personalityTrait_NAIVE = QCheckBox("Naive")
        hbox.addWidget(self.personalityTrait_NAIVE)
        hbox.addStretch()
        right_vbox.addLayout(hbox)

        hbox = QHBoxLayout()
        hbox.addStretch()
        self.personalityTrait_CYNICAL = QCheckBox("Cynical")
        hbox.addWidget(self.personalityTrait_CYNICAL)
        self.personalityTrait_BRAVE = QCheckBox("Brave")
        hbox.addWidget(self.personalityTrait_BRAVE)
        self.personalityTrait_COWARDLY = QCheckBox("Cowardly")
        hbox.addWidget(self.personalityTrait_COWARDLY)
        self.personalityTrait_LEWD = QCheckBox("Lewd")
        hbox.addWidget(self.personalityTrait_LEWD)
        self.personalityTrait_INNOCENT = QCheckBox("Innocent")
        hbox.addWidget(self.personalityTrait_INNOCENT)
        hbox.addStretch()
        right_vbox.addLayout(hbox)

        hbox = QHBoxLayout()
        hbox.addStretch()
        self.personalityTrait_PRUDE = QCheckBox("Prude")
        hbox.addWidget(self.personalityTrait_PRUDE)
        self.personalityTrait_LISP = QCheckBox("Lisp")
        hbox.addWidget(self.personalityTrait_LISP)
        self.personalityTrait_STUTTER = QCheckBox("Stutter")
        hbox.addWidget(self.personalityTrait_STUTTER)
        self.personalityTrait_MUTE = QCheckBox("Mute")
        hbox.addWidget(self.personalityTrait_MUTE)
        self.personalityTrait_SLOVENLY = QCheckBox("Slovenly")
        hbox.addWidget(self.personalityTrait_SLOVENLY)
        hbox.addStretch()
        right_vbox.addLayout(hbox)

        right_vbox.addStretch()

        # endregion

        layout.addLayout(left_vbox)
        layout.addLayout(right_vbox)


class AttributesTab(QWidget):
    def __init__(self, parent=None):
        super(AttributesTab, self).__init__(parent)
        layout = QHBoxLayout(self)
        layout.addStretch()

        # region Left VBox

        left_vbox = QVBoxLayout()
        left_vbox.addStretch()
        left_vbox.setSpacing(10)

        hbox, self.attributes_HEALTH_MAXIMUM = create_labeled_line_edit("Health Core:", center=True)
        left_vbox.addLayout(hbox)

        hbox, self.attributes_MANA_MAXIMUM = create_labeled_line_edit("Mana Core:", center=True)
        left_vbox.addLayout(hbox)

        hbox, self.attributes_EXPERIENCE = create_labeled_line_edit("Experience:", center=True)
        left_vbox.addLayout(hbox)

        hbox, self.attributes_ACTION_POINTS = create_labeled_line_edit("Action Points:", center=True)
        left_vbox.addLayout(hbox)

        hbox, self.attributes_AROUSAL = create_labeled_line_edit("Arousal:", center=True)
        left_vbox.addLayout(hbox)

        hbox, self.attributes_LUST = create_labeled_line_edit("Lust Core:", center=True)
        left_vbox.addLayout(hbox)

        hbox, self.attributes_RESTING_LUST = create_labeled_line_edit("Resting Lust:", center=True)
        left_vbox.addLayout(hbox)

        hbox, self.attributes_MAJOR_PHYSIQUE = create_labeled_line_edit("Physique Core:", center=True)
        left_vbox.addLayout(hbox)

        hbox, self.attributes_MAJOR_ARCANE = create_labeled_line_edit("Arcane Core:", center=True)
        left_vbox.addLayout(hbox)

        hbox, self.attributes_MAJOR_CORRUPTION = create_labeled_line_edit("Corruption Core:", center=True)
        left_vbox.addLayout(hbox)

        hbox, self.attributes_ENCHANTMENT_LIMIT = create_labeled_line_edit("Enchantment Limit:", center=True)
        left_vbox.addLayout(hbox)

        hbox, self.attributes_FERTILITY = create_labeled_line_edit("Fertility:", center=True)
        left_vbox.addLayout(hbox)

        hbox, self.attributes_VIRILITY = create_labeled_line_edit("Virility:", center=True)
        left_vbox.addLayout(hbox)

        hbox, self.attributes_SPELL_COST_MODIFIER = create_labeled_line_edit("Spell Cost Modifier:", center=True)
        left_vbox.addLayout(hbox)

        hbox, self.attributes_CRITICAL_DAMAGE = create_labeled_line_edit("Critical Damage:", center=True)
        left_vbox.addLayout(hbox)

        left_vbox.addStretch()

        # endregion

        # region Right VBox

        right_vbox = QVBoxLayout()
        right_vbox.addStretch()
        right_vbox.setSpacing(10)

        hbox, self.attributes_ENERGY_SHIELDING = create_labeled_line_edit("Energy Shielding:", center=True)
        right_vbox.addLayout(hbox)

        hbox, self.attributes_RESISTANCE_PHYSICAL = create_labeled_line_edit("Physical Resistance:", center=True)
        right_vbox.addLayout(hbox)

        hbox, self.attributes_RESISTANCE_LUST = create_labeled_line_edit("Lust Resistance:", center=True)
        right_vbox.addLayout(hbox)

        hbox, self.attributes_RESISTANCE_FIRE = create_labeled_line_edit("Fire Resistance:", center=True)
        right_vbox.addLayout(hbox)

        hbox, self.attributes_RESISTANCE_ICE = create_labeled_line_edit("Ice Resistance:", center=True)
        right_vbox.addLayout(hbox)

        hbox, self.attributes_RESISTANCE_POISON = create_labeled_line_edit("Poison Resistance:", center=True)
        right_vbox.addLayout(hbox)

        hbox, self.attributes_DAMAGE_UNARMED = create_labeled_line_edit("Unarmed Damage:", center=True)
        right_vbox.addLayout(hbox)

        hbox, self.attributes_DAMAGE_MELEE_WEAPON = create_labeled_line_edit("Melee Damage:", center=True)
        right_vbox.addLayout(hbox)

        hbox, self.attributes_DAMAGE_RANGED_WEAPON = create_labeled_line_edit("Ranged Damage:", center=True)
        right_vbox.addLayout(hbox)

        hbox, self.attributes_DAMAGE_SPELLS = create_labeled_line_edit("Spell Damage:", center=True)
        right_vbox.addLayout(hbox)

        hbox, self.attributes_DAMAGE_PHYSICAL = create_labeled_line_edit("Physical Damage:", center=True)
        right_vbox.addLayout(hbox)

        hbox, self.attributes_DAMAGE_LUST = create_labeled_line_edit("Lust Damage:", center=True)
        right_vbox.addLayout(hbox)

        hbox, self.attributes_DAMAGE_FIRE = create_labeled_line_edit("Fire Damage:", center=True)
        right_vbox.addLayout(hbox)

        hbox, self.attributes_DAMAGE_ICE = create_labeled_line_edit("Ice Damage:", center=True)
        right_vbox.addLayout(hbox)

        hbox, self.attributes_DAMAGE_POISON = create_labeled_line_edit("Poison Damage:", center=True)
        right_vbox.addLayout(hbox)

        right_vbox.addStretch()

        # endregion

        layout.addLayout(left_vbox)
        layout.addSpacing(250)
        layout.addLayout(right_vbox)
        layout.addStretch()


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


# region Body Tabs

class BodyCoreTab(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super(BodyCoreTab, self).__init__(parent)
        layout = QVBoxLayout(self)


class HeadTab(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super(HeadTab, self).__init__(parent)
        layout = QVBoxLayout(self)


class FaceTab(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super(FaceTab, self).__init__(parent)
        layout = QVBoxLayout(self)


class BreastsTab(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super(BreastsTab, self).__init__(parent)
        layout = QVBoxLayout(self)


class BreastsCrotchTab(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super(BreastsCrotchTab, self).__init__(parent)
        layout = QVBoxLayout(self)


class TorsoTab(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super(TorsoTab, self).__init__(parent)
        layout = QVBoxLayout(self)


class PenisTab(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super(PenisTab, self).__init__(parent)
        layout = QVBoxLayout(self)


class VaginaTab(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super(VaginaTab, self).__init__(parent)
        layout = QVBoxLayout(self)


class AssTab(QWidget):
    def __init__(self, parent: QWidget | None = None):
        super(AssTab, self).__init__(parent)
        layout = QVBoxLayout(self)


# endregion


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


def create_labeled_line_edit(text: str, width: int = 150, validator: QValidator | None = None, center: bool = False) -> \
tuple[QHBoxLayout, QLineEdit]:
    hbox = QHBoxLayout()
    if center:
        hbox.addStretch()
    label = QLabel(text)
    line_edit = QLineEdit()
    line_edit.setFixedWidth(width)
    line_edit.setValidator(validator)
    hbox.addWidget(label)
    hbox.addWidget(line_edit)
    hbox.addStretch()
    return hbox, line_edit


if __name__ == '__main__':
    app = QApplication(sys.argv)
    ex = LTSaveEd()
    sys.exit(app.exec_())
