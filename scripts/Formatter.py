def color_formatter():
    with open("scripts/colors.txt", "r") as f:
        colors = f.readlines()
    colors = [d.strip() for d in colors]
    with open("scripts/java_colors.txt", "w") as f:
        f.write("private final ObservableList<Attribute> colorAttributeValues = FXCollections.observableArrayList(\n")
        for color in colors:
            color_split = color.split("_")
            if len(color_split) == 1:
                f.write(f'new Attribute("{color.title()}", "{color}"), ')
            else:
                c = color_split[0]
                desc = " ".join(color_split[1:])
                formatted_color = f"{desc.title()} {c.title()}"
                f.write(f'new Attribute("{formatted_color}", "{color}"), ')
        f.write(");")

    """private final ObservableList<Attribute> femininityAttributeValues = FXCollections.observableArrayList(
            new Attribute("Very Masculine", "VERY_MASCULINE"),
            new Attribute("Masculine", "MASCULINE"), new Attribute("Androgynous", "ANDROGYNOUS"),
            new Attribute("Feminine", "FEMININE"), new Attribute("Very Feminine", "VERY_FEMININE"));"""

if __name__ == '__main__':
    color_formatter()
