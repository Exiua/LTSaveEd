/**
 * Get the value of a local storage item
 * @param key {string} The key of the item to get
 * @returns {string} The value of the item
 */
export function get(key)
{
    return window.localStorage.getItem(key);
}

/**
 * Check if a local storage item exists
 * @param key {string} The key of the item to check
 * @returns {boolean} True if the item exists, false otherwise
 */
export function exists(key)
{
    return window.localStorage.getItem(key) !== null;
}

/**
 * Set the value of a local storage item
 * @param key {string} The key of the item to set
 * @param value {any} The value to set (values are coerced to strings)
 */
export function set(key, value)
{
    window.localStorage.setItem(key, value);
}

/**
 * Clear all local storage items
 */
export function clear()
{
    window.localStorage.clear();
}

/**
 * Remove a local storage item
 * @param key {string} The key of the item to remove
 */
export function remove(key)
{
    window.localStorage.removeItem(key);
}