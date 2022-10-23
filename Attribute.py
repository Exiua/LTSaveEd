class Attribute:
    def __init__(self, name: str, value: str):
        self.name: str = name
        self.value: str = value

    def __str__(self):
        return self.value

    def __eq__(self, other):
        if isinstance(other, str):
            return self.value == other
        if isinstance(other, Attribute):
            return self.value == other.value
        raise Exception(f"Equality not defined between Attribute and {type(other)}")


if __name__ == '__main__':
    pass
