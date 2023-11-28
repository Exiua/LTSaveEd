import sys
from pathlib import Path

def main(path: str):
    filepath = Path(path)
    file_size = filepath.stat().st_size
    add_size = 10485760 - file_size
    with filepath.open("ab") as f:
        f.write(b"\x00" * add_size)

if __name__ == "__main__":
    main(sys.argv[1])
