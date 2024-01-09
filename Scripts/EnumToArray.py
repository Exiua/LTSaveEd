def main():
    with open("in.txt", "r") as f:
        data = f.readlines()
    
    enum_type = "ClothingType"
    data = [dat.split(",")[0] for dat in data]
    data = [f'new ValueDisplayPair<{enum_type}>("{dat}", {enum_type}.{dat})' for dat in data]
    data = "[\n" + ", ".join(data) + "\n]"
    data = [data]

    with open("out.txt", "w") as f:
        f.writelines(data)

if __name__ == "__main__":
    main()