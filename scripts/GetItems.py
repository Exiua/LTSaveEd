import sys
import os


def get_items(filepath: str):
    top_files = next(os.walk(filepath), (None, None, []))[2]
    if not any(ext in file for file in top_files for ext in ("LT.exe", ".jar")):  # Basic sanity check for game dir
        raise Exception("Filepath to game not provided: " + filepath)
    res_dir_path = os.path.join(filepath, "res")
    clothing_dir_path = os.path.join(res_dir_path, "clothing")
    items_dir_path = os.path.join(res_dir_path, "items")
    weapons_dir_path = os.path.join(res_dir_path, "weapons")
    clothing_ids = get_item_ids(clothing_dir_path)
    item_ids = get_item_ids(items_dir_path)
    weapon_ids = get_item_ids(weapons_dir_path)


def get_item_ids(item_dir_path) -> list[str]:
    item_ids = []
    contributors = os.listdir(item_dir_path)
    for contributor in contributors:
        contributor_subdir_path = os.path.join(item_dir_path, contributor)
        _, contributor_directories, contributor_files = next(os.walk(contributor_subdir_path), (None, [], []))
        for directory in contributor_directories:
            items = os.listdir(os.path.join(contributor_subdir_path, directory))
            for item in items:
                if ".xml" not in item:
                    continue
                item_id = f"{contributor}_{directory}_{item.replace('.xml', '')}"
                item_ids.append(item_id)
        for file in contributor_files:
            if ".xml" not in file:
                continue
            item_id = f"{contributor}_{file.replace('.xml', '')}"
            item_ids.append(item_id)
    return item_ids


if __name__ == '__main__':
    get_items(sys.argv[1])
