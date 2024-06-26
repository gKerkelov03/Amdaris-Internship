import { useCallback, useState } from 'react';

const useToggle = (initialValue: boolean = false): [boolean, () => void] => {
    const [value, setValue] = useState(initialValue);

    const toggleValue = useCallback(() => {
        setValue((prevValue) => !prevValue);
    }, []);

    return [value, toggleValue];
};

export default useToggle;
