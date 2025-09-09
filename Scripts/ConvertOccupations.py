def main():
    # Input file is expected to be the enum values from the Occupation enum in the `Occupation.java` file (left-aligned).
    # The values should all text from after the enum starting brace to before the `// Player histories:` comment.
    # Output file will be a list of calls to new() with the display name and enum value. These values can be copied
    # into the NpcJobHistories property in the `Core.cs` file.
    with open("input.txt", "r") as f:
        lines = f.readlines()
    
    output = []
    skip_level = 0
    for line in lines:
        if skip_level > 0: # Skip code bits
            if "}" in line:
                skip_level -= 1
            if "{" in line:
                skip_level += 1
            continue

        line = line.strip()
        if line == "": # Skip empty lines
            continue
        if line.startswith("//"): # Skip comments
            continue

        if "{" in line:
            skip_level += 1

        prefix = line.split("(")[0]
        value = prefix
        display_name = generate_display_name(prefix)
        out = f'new("{display_name}", "{value}"),\n'
        output.append(out)
    
    with open("output.txt", "w") as f:
        f.writelines(output)

def generate_display_name(prefix: str) -> str:
    """
        Generate the display name from the enum value prefix.
        E.g. NPC_ENFORCER_ORICL_INSPECTOR -> "Enforcer Oricl Inspector"
    :param prefix: The enum value string.
    :return: The display name string.
    """
    prefix = prefix.replace("NPC_", "")
    parts = prefix.split("_")
    display_name = " ".join(part.capitalize() for part in parts)
    return display_name
        

if __name__ == "__main__":
    main()
